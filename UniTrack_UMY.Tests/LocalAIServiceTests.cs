using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UniTrack_UMY.Core.AI;
using UniTrack_UMY.Infrastructure.AI;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class LocalAIServiceTests
    {
        [Fact]
        public async Task Connection_reports_NotRunning_on_HttpRequestException()
        {
            var http = new HttpClient(new FakeHttpMessageHandler(_ =>
                throw new HttpRequestException("boom")))
            { Timeout = Timeout.InfiniteTimeSpan };
            using var svc = new LocalAIService(
                new OllamaClient(new OllamaOptions(), http, true));

            var st = await svc.GetConnectionStateAsync();
            Assert.Equal(AIConnectionStateKind.OllamaNotRunning, st.Kind);
        }

        [Fact]
        public async Task Connection_reports_Timeout_on_TaskCanceled()
        {
            var http = new HttpClient(new FakeHttpMessageHandler(_ =>
                throw new TaskCanceledException()))
            { Timeout = Timeout.InfiniteTimeSpan };
            using var svc = new LocalAIService(
                new OllamaClient(new OllamaOptions(), http, true));

            var st = await svc.GetConnectionStateAsync();
            Assert.Equal(AIConnectionStateKind.Timeout, st.Kind);
        }

        [Fact]
        public async Task Connection_Connected_when_models_present()
        {
            const string json = "{\"models\":[{\"name\":\"qwen3.5:9b-8k\",\"size\":1}]}";
            var http = new HttpClient(new FakeHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                { Content = new StringContent(json) }))
            { Timeout = Timeout.InfiniteTimeSpan };
            using var svc = new LocalAIService(
                new OllamaClient(new OllamaOptions(), http, true));

            var st = await svc.GetConnectionStateAsync();
            Assert.True(st.IsConnected);
        }
    }
}