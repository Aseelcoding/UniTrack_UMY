using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UniTrack_UMY.Infrastructure.AI
{
    internal sealed class OllamaTagsResponse
    {
        [JsonPropertyName("models")]
        public List<OllamaModel> Models { get; set; } = new List<OllamaModel>();
    }

    internal sealed class OllamaModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime? ModifiedAt { get; set; }

        [JsonPropertyName("details")]
        public OllamaModelDetails? Details { get; set; }
    }

    internal sealed class OllamaModelDetails
    {
        [JsonPropertyName("family")]
        public string Family { get; set; } = string.Empty;

        [JsonPropertyName("parameter_size")]
        public string ParameterSize { get; set; } = string.Empty;
    }

    internal sealed class OllamaChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("messages")]
        public List<OllamaChatMessage> Messages { get; set; } =
            new List<OllamaChatMessage>();

        [JsonPropertyName("stream")]
        public bool Stream { get; set; }

        [JsonPropertyName("options")]
        public OllamaChatRequestOptions? Options { get; set; }
    }

    internal sealed class OllamaChatRequestOptions
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("num_predict")]
        public int? NumPredict { get; set; }
    }

    internal sealed class OllamaChatMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = "user";

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }

    internal sealed class OllamaChatResponse
    {
        [JsonPropertyName("message")]
        public OllamaChatMessage? Message { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}