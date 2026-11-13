namespace UniTrack_UMY.Core.AI
{
    public enum AIConnectionStateKind
    {
        Connected,
        OllamaNotRunning,
        ModelMissing,
        Timeout,
        Error
    }

    public sealed class AIConnectionState
    {
        public AIConnectionStateKind Kind { get; }
        public string Message { get; }

        public AIConnectionState(AIConnectionStateKind kind, string message)
        {
            Kind = kind;
            Message = message ?? string.Empty;
        }

        public bool IsConnected => Kind == AIConnectionStateKind.Connected;

        public static AIConnectionState Connected(string message = "Connected") =>
            new AIConnectionState(AIConnectionStateKind.Connected, message);

        public static AIConnectionState NotRunning(string message) =>
            new AIConnectionState(AIConnectionStateKind.OllamaNotRunning, message);

        public static AIConnectionState ModelMissing(string message) =>
            new AIConnectionState(AIConnectionStateKind.ModelMissing, message);

        public static AIConnectionState Timeout(string message) =>
            new AIConnectionState(AIConnectionStateKind.Timeout, message);

        public static AIConnectionState Error(string message) =>
            new AIConnectionState(AIConnectionStateKind.Error, message);
    }
}