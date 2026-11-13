using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UniTrack_UMY.Core.AI
{
    public interface IAIService
    {
        Task<AIConnectionState> GetConnectionStateAsync(
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<AIModelInfo>> ListModelsAsync(
            CancellationToken cancellationToken = default);

        Task<string> ChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            CancellationToken cancellationToken = default);

        IAsyncEnumerable<AIChatChunk> StreamChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            CancellationToken cancellationToken = default);
    }
}