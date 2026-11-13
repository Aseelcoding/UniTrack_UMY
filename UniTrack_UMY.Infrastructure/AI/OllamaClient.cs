using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.AI;

namespace UniTrack_UMY.Infrastructure.AI
{
    public sealed class OllamaClient : IDisposable
    {
        private static readonly JsonSerializerOptions JsonOptions =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition =
                    System.Text.Json.Serialization.JsonIgnoreCondition
                        .WhenWritingNull
            };

        private readonly HttpClient _http;
        private readonly OllamaOptions _options;
        private readonly bool _ownsHttpClient;

        public OllamaClient(OllamaOptions options)
            : this(options, new HttpClient { Timeout = Timeout.InfiniteTimeSpan }, true)
        {
        }

        public OllamaClient(OllamaOptions options, HttpClient httpClient, bool ownsHttpClient)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _ownsHttpClient = ownsHttpClient;
        }

        public async Task<List<AIModelInfo>> GetTagsAsync(
            CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                _options.BaseUrl + "/api/tags");

            try
            {
                    using HttpResponseMessage response = await _http
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken)
                    .ConfigureAwait(false);


                response.EnsureSuccessStatusCode();

                await using Stream stream = await response.Content
                    .ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

                OllamaTagsResponse? parsed =
                    await JsonSerializer.DeserializeAsync<OllamaTagsResponse>(
                        stream, JsonOptions, cancellationToken).ConfigureAwait(false);

                var result = new List<AIModelInfo>();
                if (parsed?.Models == null)
                    return result;

                foreach (OllamaModel model in parsed.Models)
                {
                    result.Add(new AIModelInfo
                    {
                        Name = model.Name,
                        SizeBytes = model.Size,
                        ModifiedAt = model.ModifiedAt,
                        Family = model.Details?.Family ?? string.Empty,
                        ParameterSize = model.Details?.ParameterSize ?? string.Empty
                    });
                }
                return result;
            }
            catch(Exception ex) 
            {
                throw;
            }
        
        }

        public async Task<string> ChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            CancellationToken cancellationToken)
        {
            using CancellationTokenSource cts =
                CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(options.Timeout);

            OllamaChatRequest body = BuildRequest(messages, options, stream: false);

            using var request = new HttpRequestMessage(
                HttpMethod.Post, _options.BaseUrl + "/api/chat");
            request.Content = new StringContent(
                JsonSerializer.Serialize(body, JsonOptions),
                Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _http
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            await using Stream stream = await response.Content
                .ReadAsStreamAsync(cts.Token).ConfigureAwait(false);

            OllamaChatResponse? parsed =
                await JsonSerializer.DeserializeAsync<OllamaChatResponse>(
                    stream, JsonOptions, cts.Token).ConfigureAwait(false);

            if (parsed == null)
                throw new InvalidOperationException("Empty response from Ollama.");

            if (!string.IsNullOrEmpty(parsed.Error))
                throw new InvalidOperationException("Ollama error: " + parsed.Error);

            return parsed.Message?.Content ?? string.Empty;
        }

        public async IAsyncEnumerable<AIChatChunk> StreamChatAsync(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using CancellationTokenSource cts =
                CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(options.Timeout);

            OllamaChatRequest body = BuildRequest(messages, options, stream: true);

            using var request = new HttpRequestMessage(
                HttpMethod.Post, _options.BaseUrl + "/api/chat");
            request.Content = new StringContent(
                JsonSerializer.Serialize(body, JsonOptions),
                Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _http
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            await using Stream stream = await response.Content
                .ReadAsStreamAsync(cts.Token).ConfigureAwait(false);

            using var reader = new StreamReader(stream, Encoding.UTF8);

            while (true)
            {
                string? line = await reader.ReadLineAsync(cts.Token)
                    .ConfigureAwait(false);
                if (line == null) yield break;
                if (string.IsNullOrWhiteSpace(line)) continue;

                OllamaChatResponse? parsed;
                try
                {
                    parsed = JsonSerializer.Deserialize<OllamaChatResponse>(
                        line, JsonOptions);
                }
                catch (JsonException)
                {
                    continue;
                }

                if (parsed == null) continue;

                if (!string.IsNullOrEmpty(parsed.Error))
                    throw new InvalidOperationException(
                        "Ollama error: " + parsed.Error);

                string content = parsed.Message?.Content ?? string.Empty;
                if (parsed.Done)
                {
                    yield return new AIChatChunk(content, isFinal: true);
                    yield break;
                }
                if (content.Length > 0)
                    yield return new AIChatChunk(content, isFinal: false);
            }
        }

        private static OllamaChatRequest BuildRequest(
            IEnumerable<AIChatMessage> messages,
            AIChatOptions options,
            bool stream)
        {
            var list = new List<OllamaChatMessage>();
            foreach (AIChatMessage m in messages)
            {
                list.Add(new OllamaChatMessage
                {
                    Role = RoleToString(m.Role),
                    Content = m.Content
                });
            }

            return new OllamaChatRequest
            {
                Model = options.ModelName,
                Messages = list,
                Stream = stream,
                Options = new OllamaChatRequestOptions
                {
                    Temperature = options.Temperature,
                    NumPredict = options.MaxTokens
                }
            };
        }

        private static string RoleToString(AIChatRole role) => role switch
        {
            AIChatRole.System => "system",
            AIChatRole.User => "user",
            AIChatRole.Assistant => "assistant",
            _ => "user"
        };

        public void Dispose()
        {
            if (_ownsHttpClient)
                _http.Dispose();
        }
    }
}