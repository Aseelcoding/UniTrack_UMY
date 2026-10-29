using System;
using System.IO;
using System.Text.Json;

namespace UniTrack_UMY.Infrastructure.Services
{
    /// <summary>
    /// Shared JSON file helpers used by the local-storage services. Provides
    /// atomic writes and automatic backup/restore so a corrupted file can be
    /// recovered instead of losing data.
    /// </summary>
    internal static class FileStore
    {
        public static string AppDataDirectory => Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "UniTrack");

        public static void EnsureDirectory(string filePath)
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// Writes JSON atomically. Before replacing an existing file, it is
        /// copied to "&lt;file&gt;.bak" so it can be used for automatic recovery.
        /// </summary>
        public static void WriteAtomic(string filePath, string json)
        {
            EnsureDirectory(filePath);

            string tempPath = filePath + "." +
                Guid.NewGuid().ToString("N") + ".tmp";

            try
            {
                File.WriteAllText(tempPath, json);

                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Copy(filePath, filePath + ".bak", overwrite: true);
                    }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }

                    File.Replace(tempPath, filePath, null);
                }
                else
                {
                    File.Move(tempPath, filePath);
                }
            }
            finally
            {
                if (File.Exists(tempPath))
                {
                    try { File.Delete(tempPath); }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                }
            }
        }

        /// <summary>
        /// Reads and deserializes JSON. If the file is corrupted, it attempts to
        /// restore from the ".bak" backup; if that fails, the corrupt file is
        /// moved aside and null is returned.
        /// </summary>
        public static T? Read<T>(string filePath) where T : class
        {
            if (!File.Exists(filePath))
                return null;

            try
            {
                return JsonSerializer.Deserialize<T>(
                    File.ReadAllText(filePath));
            }
            catch (JsonException)
            {
                return TryRestoreFromBackup<T>(filePath);
            }
            catch (IOException)
            {
                return null;
            }
        }

        private static T? TryRestoreFromBackup<T>(string filePath)
            where T : class
        {
            string backupPath = filePath + ".bak";

            if (File.Exists(backupPath))
            {
                try
                {
                    T? restored = JsonSerializer.Deserialize<T>(
                        File.ReadAllText(backupPath));

                    if (restored != null)
                    {
                        File.WriteAllText(
                            filePath,
                            JsonSerializer.Serialize(
                                restored,
                                new JsonSerializerOptions
                                {
                                    WriteIndented = true
                                }));

                        return restored;
                    }
                }
                catch (JsonException) { }
                catch (IOException) { }
            }

            MoveCorruptFile(filePath);
            return null;
        }

        private static void MoveCorruptFile(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            string backupPath = filePath + ".bad-" +
                DateTime.Now.ToString("yyyyMMddHHmmssfff");

            try
            {
                File.Move(filePath, backupPath);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}
