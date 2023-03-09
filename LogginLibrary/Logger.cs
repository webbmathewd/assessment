using System;
using System.IO;

namespace LoggingLibrary
{
    public class LoggingLibrary : ILogger
    {
        public void LogMessage(string message)
        {
            try
            {
                using (var writer = new StreamWriter("~/", true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString()} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}