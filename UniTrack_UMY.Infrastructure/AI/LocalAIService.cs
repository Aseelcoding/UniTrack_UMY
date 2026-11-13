using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.AI;

namespace UniTrack_UMY.Infrastructure.AI
{
    public sealed class LocalAIService : IAIService, IDisposable
    {
        private readonly OllamaClient _client;

        public LocalAIService(OllamaClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public LocalAIService(OllamaOptions options)
            : this(new OllamaClient(options))
        {
        }

        public async Task<AIConnectionState> GetConnectionStateAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                List<AIModelInfo> models = await _client
                    .GetTagsAsync(cancellationToken).ConfigureAwait(false);

                if (models.Count == 0)
                    return AIConnectionState.ModelMissing(
                        "Ollama is running but no models are installed.");

                return AIConnectionState.Connected(
                    $"Connected ({models.Count} model(s) available)");
            }
            catch (HttpRequestException ex)
            {
                return AIConnectionState.NotRunning(
                    "Ollama is not running. Start it with 'ollama serve'. (" +
                    ex.Message + ")");
            }
            catch (TaskCanceledException)
            {
                return AIConnectionState.Timeout(
                    "The request to Ollama timed out.");
            }
            catch (Exception ex)
            {
                return AIConnectionState.Error(
                    "Unexpected error contacting Ollama: " + ex.Message);
            }
        }

        public async Task<IReadOnlyList<AIModelInfo>> ListModelsAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _client.GetTagsAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException)
            {
                return Array.Empty<AIModelInfo>();
            }
            catch (TaskCanceledException)
            {
                return Array.Empty<AIModelInfo>();
            }
        }

        public async Task<string> ChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.ModelName))
                throw new InvalidOperationException("No AI model selected.");

            return await _client.ChatAsync(messages, options, cancellationToken)
                .ConfigureAwait(false);
        }

        public async IAsyncEnumerable<AIChatChunk> StreamChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.ModelName))
                throw new InvalidOperationException("No AI model selected.");

            await foreach (AIChatChunk chunk in _client
                .StreamChatAsync(messages, options, cancellationToken)
                .ConfigureAwait(false))
            {
                yield return chunk;
            }
        }

        public void Dispose() => _client.Dispose();
    }
}