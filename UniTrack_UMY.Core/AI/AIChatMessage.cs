namespace UniTrack_UMY.Core.AI
{
    public sealed class AIChatMessage
    {
        public AIChatRole Role { get; }
        public string Content { get; }

        public AIChatMessage(AIChatRole role, string content)
        {
            Role = role;
            Content = content ?? string.Empty;
        }

        public static AIChatMessage System(string content) =>
            new AIChatMessage(AIChatRole.System, content);

        public static AIChatMessage User(string content) =>
            new AIChatMessage(AIChatRole.User, content);

        public static AIChatMessage Assistant(string content) =>
            new AIChatMessage(AIChatRole.Assistant, content);
    }
}