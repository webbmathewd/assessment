﻿using System;
using System.IO;
using System.Reflection;
using TW.DeveloperTest.WorkLibrary;

namespace TW.DeveloperTest.WorkLibrary
{
    public class LoggingLibrary : ILogger
    {
        public string LogFilePath { get; set; }
        public string LogFormat { get; set; }
        public SeverityType LogLevelThreshhold { get; set; }


        public LoggingLibrary()
        {
            LogFilePath = "log.txt";
            LogFormat = "[{0}] - {1} - {2}";
            LogLevelThreshhold = SeverityType.Error;
        }

        public LoggingLibrary(string logFilePath, string logFormat, SeverityType logLevelThreshhold)
        {
            LogFilePath = logFilePath;
            LogFormat = logFormat;
            LogLevelThreshhold = logLevelThreshhold;
        }

        public void LogMessage(LogMessage message)
        {
            //Don't log anything below the threshold 
            if(message.Severity < LogLevelThreshhold)
            {
                return;
            }
            try
            {
                //TODO - change to write to a database, or some other format.
                string logLine = string.Format(LogFormat, DateTime.Now.ToString(), message.Severity, message.Text);
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine(logLine);
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
        Debug,
        Information,
        Warning,
        Error
    }


    public class LogMessage
    {
        public string Time { get; set; }
        public SeverityType Severity { get; set; }
        public string Text { get; set; }
    }
}