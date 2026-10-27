
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

        public WebViewHtmlFetcher(WebView2 webView)
        {
            _webView = webView ??
                throw new ArgumentNullException(nameof(webView));
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) ||
                (uri.Scheme != Uri.UriSchemeHttp &&
                 uri.Scheme != Uri.UriSchemeHttps))
            {
                return string.Empty;
            }

            await _semaphore.WaitAsync();

            try
            {
                if (_webView.CoreWebView2 == null)
                {
                    throw new InvalidOperationException(
                        "WebView2 is not initialized.");
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
                        if (expectedNavigationId != 0 &&
                            e.NavigationId == expectedNavigationId)
                        {
                            completion.TrySetResult(true);
                        }
                    };

                _webView.NavigationStarting += startingHandler;
                _webView.NavigationCompleted += completedHandler;

                try
                {
                    _webView.Source = uri;

                    Task completedTask = await Task.WhenAny(
                        completion.Task,
                        Task.Delay(TimeSpan.FromSeconds(15)));

                    if (completedTask != completion.Task)
                    {
                        throw new TimeoutException(
                            "WebView2 navigation timed out.");
                    }

                    await Task.Delay(500);

                    string json =
                        await _webView.CoreWebView2.ExecuteScriptAsync(
                            "document.documentElement.outerHTML");

                    return JsonSerializer.Deserialize<string>(json)
                        ?? string.Empty;
                }
                finally
                {
                    _webView.NavigationStarting -= startingHandler;
                    _webView.NavigationCompleted -= completedHandler;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
