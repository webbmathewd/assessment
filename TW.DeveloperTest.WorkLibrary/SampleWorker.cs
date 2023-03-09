using System;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using TW.DeveloperTest.Contracts;

namespace TW.DeveloperTest.WorkLibrary
{
    public class SampleWorker : IWorker
    {
        readonly Random _random;

        public SampleWorker()
        {
            _random = new Random();
        }

        public string GetResult()
        {
            int result = _random.Next(0, 100);

            if (result <= 95)
            {
                //TODO Log to logging library successes

                return RandomString(result);
            }

            throw new Exception($"Out of range exception - {result} > 95");
        }

        private string RandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[_random.Next(0, pool.Length)];
                builder.Append(c);
            }

            DetermineSeverity(builder.ToString());

            return builder.ToString();
        }

        private void DetermineSeverity(string message)
        {
            SeverityType severity = (SeverityType)new Random().Next(Enum.GetNames(typeof(SeverityType)).Length);
            LoggingLibrary library = new LoggingLibrary();
            LogMessage logMessage = new LogMessage()
            {
                Time = DateTime.Now.ToString(),
                Severity = severity,
                Text = message
            };

            library.LogMessage(logMessage);
        }
    }
}
