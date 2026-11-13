using System;

namespace UniTrack_UMY.Core.AI
{
    public sealed class AIModelInfo
    {
        public string Name { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public string Family { get; set; } = string.Empty;
        public string ParameterSize { get; set; } = string.Empty;
        public DateTime? ModifiedAt { get; set; }

        public string SizeDisplay =>
            SizeBytes <= 0
                ? "?"
                : SizeBytes >= 1024L * 1024L * 1024L
                    ? $"{SizeBytes / (1024d * 1024d * 1024d):0.0} GB"
                    : $"{SizeBytes / (1024d * 1024d):0} MB";
    }
}