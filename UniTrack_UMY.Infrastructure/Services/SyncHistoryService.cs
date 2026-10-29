using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    /// <summary>
    /// Persists synchronization history (timestamps, results, and failed
    /// subjects) with a 30-day retention window.
    /// </summary>
    public class SyncHistoryService
    {
        private static readonly TimeSpan Retention = TimeSpan.FromDays(30);

        private readonly string _filePath;

        public SyncHistoryService()
            : this(Path.Combine(
                FileStore.AppDataDirectory,
                "synchistory.json"))
        {
        }

        public SyncHistoryService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));

            _filePath = filePath;
            FileStore.EnsureDirectory(_filePath);
        }

        public List<SyncHistoryEntry> Load()
        {
            List<SyncHistoryEntry> entries =
                FileStore.Read<List<SyncHistoryEntry>>(_filePath)
                ?? new List<SyncHistoryEntry>();

            List<SyncHistoryEntry> pruned = Prune(entries);

            if (pruned.Count != entries.Count)
                Save(pruned);

            return pruned
                .OrderByDescending(e => e.Timestamp)
                .ToList();
        }

        public void Add(SyncHistoryEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            List<SyncHistoryEntry> entries = Load();
            entries.Add(entry);
            Save(entries);
        }

        public void Clear()
        {
            Save(new List<SyncHistoryEntry>());
        }

        private void Save(List<SyncHistoryEntry> entries)
        {
            string json = JsonSerializer.Serialize(
                entries,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            FileStore.WriteAtomic(_filePath, json);
        }

        private static List<SyncHistoryEntry> Prune(
            List<SyncHistoryEntry> entries)
        {
            DateTime cutoff = DateTime.Now - Retention;

            return entries
                .Where(e => e != null && e.Timestamp >= cutoff)
                .ToList();
        }
    }
}
