using System;
using System.IO;
using Tekla.Structures.Model;

namespace Apibim.Plugins.BuiltUpColumn.Services
{
    public enum LogLevel { Info, Warning, Error, Success }

    public static class Logger
    {
        private static readonly string _logFilePath;

        static Logger()
        {
            try
            {
                var model = new Model();
                if (model.GetConnectionStatus())
                {
                    _logFilePath = Path.Combine(model.GetInfo().ModelPath, "Apibim_BuiltUpColumn.log");
                }
            }
            catch { }
        }

        public static void Write(string message, LogLevel level = LogLevel.Info)
        {
            if (string.IsNullOrEmpty(_logFilePath)) return;

            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string levelTag = $"[{level.ToString().ToUpper()}]";
                File.AppendAllText(_logFilePath, $"{timestamp} {levelTag} {message}{Environment.NewLine}");
            }
            catch { }
        }
    }
}