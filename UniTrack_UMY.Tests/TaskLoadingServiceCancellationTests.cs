using System;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.Interfaces;
using UniTrack_UMY.Core.Models;
using UniTrack_UMY.Infrastructure.Services;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class TaskLoadingServiceCancellationTests
    {
        [Fact]
        public async Task LoadTasksAsync_WhenTokenIsCancelled_ThrowsOperationCanceledException()
        {
            var service = new TaskLoadingService(new StubHtmlFetcher());
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            await Assert.ThrowsAnyAsync<OperationCanceledException>(
                () => service.LoadTasksAsync(
                    Array.Empty<Course>(),
                    cancellation.Token));
        }

        private sealed class StubHtmlFetcher : IHtmlFetcher
        {
            public Task<string> GetHtmlAsync(
                string url,
                CancellationToken cancellationToken = default)
            {
                return Task.FromResult(string.Empty);
            }
        }
    }
}