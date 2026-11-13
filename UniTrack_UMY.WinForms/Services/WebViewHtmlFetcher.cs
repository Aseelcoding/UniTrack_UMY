
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using UniTrack_UMY.Core.Interfaces;

namespace UniTrack_UMY.WinForms.Services
{
    public sealed class WebViewHtmlFetcher : IHtmlFetcher
    {
        private readonly WebView2 _webView;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private static readonly TimeSpan NavigationTimeout =
            TimeSpan.FromSeconds(30);

        public WebViewHtmlFetcher(WebView2 webView)
        {
            _webView = webView ??
                throw new ArgumentNullException(nameof(webView));
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            if (!Uri.TryCreate(
                    url,
                    UriKind.Absolute,
                    out Uri? uri) ||
                (uri.Scheme != Uri.UriSchemeHttp &&
                 uri.Scheme != Uri.UriSchemeHttps))
            {
                return string.Empty;
            }

            await _semaphore.WaitAsync();

            try
            {
                if (_webView.IsDisposed ||
                    !_webView.IsHandleCreated)
                {
                    throw new InvalidOperationException(
                        "WebView2 control is not available.");
                }

                if (_webView.CoreWebView2 == null)
                {
                    throw new InvalidOperationException(
                        "WebView2 is not initialized. " +
                        "Call EnsureCoreWebView2Async first.");
                }

                var completion = new TaskCompletionSource<bool>(
                    TaskCreationOptions.RunContinuationsAsynchronously);

                ulong expectedNavigationId = 0;

                EventHandler<CoreWebView2NavigationStartingEventArgs>
                    startingHandler = (sender, e) =>
                    {
                        expectedNavigationId = e.NavigationId;
                    };

                EventHandler<CoreWebView2NavigationCompletedEventArgs>
                    completedHandler = (sender, e) =>
                    {
                        if (expectedNavigationId == 0 ||
                            e.NavigationId != expectedNavigationId)
                        {
                            return;
                        }

                        if (e.IsSuccess)
                        {
                            completion.TrySetResult(true);
                        }
                        else
                        {
                            completion.TrySetException(
                                new InvalidOperationException(
                                    "WebView2 navigation failed: " +
                                    e.WebErrorStatus));
                        }
                    };

                CoreWebView2 core = _webView.CoreWebView2;

                core.NavigationStarting += startingHandler;
                core.NavigationCompleted += completedHandler;

                try
                {
                    core.Navigate(uri.AbsoluteUri);

                    Task timeoutTask = Task.Delay(NavigationTimeout);

                    Task completedTask = await Task.WhenAny(
                        completion.Task,
                        timeoutTask);

                    if (completedTask != completion.Task)
                    {
                        core.Stop();

                        throw new TimeoutException(
                            $"WebView2 navigation timed out after " +
                            $"{NavigationTimeout.TotalSeconds} seconds. " +
                            $"URL: {uri.AbsoluteUri}");
                    }

                    await completion.Task;

                    // Allow dynamically rendered page content to settle.
                    await Task.Delay(1000);

                    string json = await core.ExecuteScriptAsync(
                        "document.documentElement.outerHTML");

                    return JsonSerializer.Deserialize<string>(json)
                        ?? string.Empty;
                }
                finally
                {
                    core.NavigationStarting -= startingHandler;
                    core.NavigationCompleted -= completedHandler;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
