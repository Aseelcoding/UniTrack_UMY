namespace UniTrack_UMY.Core.AI
{
    public readonly struct AIChatChunk
    {
        public string Content { get; }
        public bool IsFinal { get; }

        public AIChatChunk(string content, bool isFinal)
        {
            Content = content ?? string.Empty;
            IsFinal = isFinal;
        }
    }
}