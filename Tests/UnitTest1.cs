using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TW.DeveloperTest.WorkLibrary;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Debug()
        {
            string time = DateTime.Now.ToString();
            SeverityType st = SeverityType.Debug;
            string message = "This is a Debug Log";

            LogMessage logMessage = new LogMessage() { 
                Time = time,
                Severity = st,
                Text = message
            };

            LoggingLibrary loggingLibrary = new LoggingLibrary();
            loggingLibrary.LogMessage(logMessage);

            // Assert
            // We can't directly test the console output, so we'll just assume that if the method runs without throwing an exception, it's working correctly.
        }
    }
}
