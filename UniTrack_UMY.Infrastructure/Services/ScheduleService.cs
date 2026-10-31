using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UniTrack_UMY.Core.Models;

namespace UniTrack_UMY.Infrastructure.Services
{
    public class ScheduleService
    {
        private const string FileName = "schedule.json";

        public List<ScheduleItem> Load()
        {
            string filePath = Path.Combine(
                FileStore.AppDataDirectory,
                FileName);

            return FileStore.Read<List<ScheduleItem>>(filePath)
                   ?? new List<ScheduleItem>();
        }

        public void Save(List<ScheduleItem> schedule)
        {
            string filePath = Path.Combine(
                FileStore.AppDataDirectory,
                FileName);

            FileStore.EnsureDirectory(filePath);

            string json = JsonSerializer.Serialize(
                schedule,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            FileStore.WriteAtomic(filePath, json);
        }
    }
}