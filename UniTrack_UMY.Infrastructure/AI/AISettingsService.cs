using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UniTrack_UMY.Core.AI;

namespace UniTrack_UMY.Infrastructure.AI
{
    public sealed class AISettings
    {
        public string SelectedModel { get; set; } = string.Empty;
        public string CodingModelOverride { get; set; } = string.Empty;
    }

    public sealed class AISettingsService
    {
        private readonly string _path;

        public AISettingsService()
            : this(Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "UniTrack",
                "ai-settings.json"))
        {
        }

        public AISettingsService(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be empty.", nameof(path));

            _path = path;
            string? dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);
        }

        public AISettings Load()
        {
            if (!File.Exists(_path))
                return new AISettings();

            try
            {
                string json = File.ReadAllText(_path);
                return JsonSerializer.Deserialize<AISettings>(json)
                       ?? new AISettings();
            }
            catch (JsonException)
            {
                return new AISettings();
            }
            catch (IOException)
            {
                return new AISettings();
            }
        }

        public void Save(AISettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            string json = JsonSerializer.Serialize(
                settings, new JsonSerializerOptions { WriteIndented = true });
            string? dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(_path, json);
        }

        public string SuggestDefaultModel(IReadOnlyList<AIModelInfo> models)
        {
            if (models == null || models.Count == 0) return string.Empty;

            // 1) Prefer qwen3.5:9b-8k (best fit for this hardware)
            var preferred = models.FirstOrDefault(m =>
                string.Equals(m.Name, "qwen3.5:9b-8k",
                    StringComparison.OrdinalIgnoreCase));
            if (preferred != null) return preferred.Name;

            // 2) Any qwen model, smallest first
            var anyQwen = models
                .Where(m => m.Name.IndexOf("qwen",
                    StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(m => m.SizeBytes)
                .FirstOrDefault();
            if (anyQwen != null) return anyQwen.Name;

            // 3) Smallest model overall
            return models.OrderBy(m => m.SizeBytes).First().Name;
        }
    }
}