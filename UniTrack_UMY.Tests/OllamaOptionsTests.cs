using System;
using UniTrack_UMY.Infrastructure.AI;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class OllamaOptionsTests
    {
        [Theory]
        [InlineData("http://127.0.0.1:11434")]
        [InlineData("http://localhost:11434")]
        [InlineData("http://[::1]:11434")]
        public void Accepts_loopback_urls(string url)
        {
            var o = new OllamaOptions(url);
            Assert.Equal(url.TrimEnd('/'), o.BaseUrl);
        }

        [Theory]
        [InlineData("http://example.com:11434")]
        [InlineData("http://10.0.0.5:11434")]
        public void Rejects_non_loopback(string url)
        {
            Assert.Throws<ArgumentException>(() => new OllamaOptions(url));
        }

        [Theory]
        [InlineData("")]
        [InlineData("not a url")]
        [InlineData("ftp://127.0.0.1")]
        public void Rejects_invalid(string url)
        {
            Assert.Throws<ArgumentException>(() => new OllamaOptions(url));
        }
    }
}