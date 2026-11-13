using System;
using System.Collections.Generic;
using System.IO;
using UniTrack_UMY.Core.AI;
using UniTrack_UMY.Infrastructure.AI;
using Xunit;

namespace UniTrack_UMY.Tests
{
    public class AISettingsServiceTests
    {
        [Fact]
        public void Round_trip_preserves_selected_model()
        {
            string path = Path.Combine(Path.GetTempPath(),
                "unitrack-ai-" + Guid.NewGuid().ToString("N") + ".json");
            try
            {
                var svc = new AISettingsService(path);
                svc.Save(new AISettings { SelectedModel = "qwen3.5:9b-8k" });
                var loaded = new AISettingsService(path).Load();
                Assert.Equal("qwen3.5:9b-8k", loaded.SelectedModel);
            }
            finally { if (File.Exists(path)) File.Delete(path); }
        }

        [Fact]
        public void Suggest_prefers_qwen3_5_9b_8k()
        {
            var models = new List<AIModelInfo>
            {
                new() { Name = "qwen2.5-coder:7b", SizeBytes = 4_700_000_000 },
                new() { Name = "qwen3.5:9b-8k",    SizeBytes = 6_600_000_000 },
                new() { Name = "qwen3.8:27b",      SizeBytes = 17_000_000_000 },
            };
            string picked = new AISettingsService(
                Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json"))
                .SuggestDefaultModel(models);
            Assert.Equal("qwen3.5:9b-8k", picked);
        }

        [Fact]
        public void Suggest_falls_back_to_smallest_qwen()
        {
            var models = new List<AIModelInfo>
            {
                new() { Name = "llama3:70b", SizeBytes = 40_000_000_000 },
                new() { Name = "qwen2.5-coder:7b", SizeBytes = 4_700_000_000 },
                new() { Name = "qwen3.8:27b", SizeBytes = 17_000_000_000 },
            };
            string picked = new AISettingsService(
                Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json"))
                .SuggestDefaultModel(models);
            Assert.Equal("qwen2.5-coder:7b", picked);
        }

        [Fact]
        public void Suggest_falls_back_to_smallest_overall()
        {
            var models = new List<AIModelInfo>
            {
                new() { Name = "llama3:70b", SizeBytes = 40_000_000_000 },
                new() { Name = "phi3:mini",  SizeBytes = 2_300_000_000 },
            };
            string picked = new AISettingsService(
                Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json"))
                .SuggestDefaultModel(models);
            Assert.Equal("phi3:mini", picked);
        }
    }
}