using System;

namespace UniTrack_UMY.Core.AI
{
    public sealed class AIChatOptions
    {
        public string ModelName { get; set; } = string.Empty;
        public double Temperature { get; set; } = 0.3;
        public int? MaxTokens { get; set; }
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);
    }
}