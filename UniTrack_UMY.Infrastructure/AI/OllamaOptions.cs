using System;

namespace UniTrack_UMY.Infrastructure.AI
{
    public sealed class OllamaOptions
    {
        public const string DefaultBaseUrl = "http://127.0.0.1:11434";

        public string BaseUrl { get; }
        public int RequestTimeoutSeconds { get; set; } = 120;

        public OllamaOptions(string baseUrl = DefaultBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException(
                    "BaseUrl cannot be empty.", nameof(baseUrl));

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out Uri? uri))
                throw new ArgumentException(
                    "BaseUrl must be an absolute URI.", nameof(baseUrl));

            if (!uri.IsLoopback)
                throw new ArgumentException(
                    "Ollama BaseUrl must point to the local machine (loopback). " +
                    "Sending academic data to remote hosts is not allowed.",
                    nameof(baseUrl));

            BaseUrl = baseUrl.TrimEnd('/');
        }
    }
}