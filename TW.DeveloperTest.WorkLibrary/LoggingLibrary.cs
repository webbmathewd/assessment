using System;
using System.IO;
using System.Reflection;
using TW.DeveloperTest.WorkLibrary;

namespace TW.DeveloperTest.WorkLibrary
{
    public class LoggingLibrary : ILogger
    {
        private readonly string _logFilePath;

        public LoggingLibrary()
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _logFilePath = Path.Combine(exePath, "log.txt");
        }
        public void LogMessage(SeverityType severity, string message)
        {
            try
            {
                using (var writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString()} - {severity.ToString().ToUpper()} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

    }

    public enum SeverityType
    {
        Error, 
        Warning, 
        Debug
    }
}