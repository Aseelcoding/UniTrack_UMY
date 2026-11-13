using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.AI;
using UniTrack_UMY.Infrastructure.AI;
using Xunit;

namespace UniTrack_UMY.Tests
{
    internal sealed class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _fn;
        public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> fn) => _fn = fn;
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken ct) => Task.FromResult(_fn(request));
    }

    public class OllamaClientTests
    {
        private static OllamaClient Build(Func<HttpRequestMessage, HttpResponseMessage> fn)
        {
            var http = new HttpClient(new FakeHttpMessageHandler(fn))
            { Timeout = Timeout.InfiniteTimeSpan };
            return new OllamaClient(new OllamaOptions(), http, ownsHttpClient: true);
        }

        [Fact]
        public async Task GetTags_parses_models()
        {
            string json = """
            {"models":[
              {"name":"qwen3.5:9b-8k","size":6600000000,
               "details":{"family":"qwen3","parameter_size":"9B"}},
              {"name":"qwen2.5-coder:7b","size":4700000000,
               "details":{"family":"qwen2","parameter_size":"7B"}}
            ]}
            """;
            var client = Build(_ => new HttpResponseMessage(HttpStatusCode.OK)
            { Content = new StringContent(json, Encoding.UTF8, "application/json") });

            var models = await client.GetTagsAsync(CancellationToken.None);
            Assert.Equal(2, models.Count);
            Assert.Equal("qwen3.5:9b-8k", models[0].Name);
            Assert.Equal("qwen3", models[0].Family);
        }

        [Fact]
        public async Task StreamChat_parses_ndjson_chunks()
        {
            string ndjson =
                "{\"message\":{\"role\":\"assistant\",\"content\":\"Hel\"},\"done\":false}\n" +
                "{\"message\":{\"role\":\"assistant\",\"content\":\"lo\"},\"done\":false}\n" +
                "{\"message\":{\"role\":\"assistant\",\"content\":\"!\"},\"done\":true}\n";

            var client = Build(_ => new HttpResponseMessage(HttpStatusCode.OK)
            { Content = new StringContent(ndjson, Encoding.UTF8, "application/x-ndjson") });

            var chunks = new List<AIChatChunk>();
            await foreach (var c in client.StreamChatAsync(
                new[] { AIChatMessage.User("hi") },
                new AIChatOptions { ModelName = "m" },
                CancellationToken.None))
            {
                chunks.Add(c);
            }

            Assert.Equal(3, chunks.Count);
            Assert.Equal("Hel", chunks[0].Content);
            Assert.True(chunks[^1].IsFinal);
        }

        [Fact]
        public async Task StreamChat_skips_malformed_lines()
        {
            string ndjson =
                "{\"message\":{\"content\":\"a\"},\"done\":false}\n" +
                "not json\n" +
                "{\"message\":{\"content\":\"b\"},\"done\":true}\n";

            var client = Build(_ => new HttpResponseMessage(HttpStatusCode.OK)
            { Content = new StringContent(ndjson, Encoding.UTF8, "application/x-ndjson") });

            var chunks = new List<AIChatChunk>();
            await foreach (var c in client.StreamChatAsync(
                new[] { AIChatMessage.User("x") },
                new AIChatOptions { ModelName = "m" },
                CancellationToken.None))
                chunks.Add(c);

            Assert.Equal(2, chunks.Count);
        }
    }
}