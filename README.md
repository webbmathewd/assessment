Logging Library
This is a simple logging library for C# applications. It provides a simple way to log messages to a text file with different log levels (Debug, Warning, Information, and Error).

Installation
To use the Logging Library in your C# application, you'll need to include the LoggingLibrary.dll file in your project. You can do this by downloading the LoggingLibrary.dll file and adding it as a reference in your Visual Studio project.

Alternatively, you can build the LoggingLibrary project from source and include the resulting DLL file in your project.

Usage
To use the Logging Library in your C# application, you'll need to create an instance of the Logger class and call its Log method to log messages. Here's an example:

using LoggingLibrary;

// Create a LoggingLibrary instance
LoggingLibrary library = new LoggingLibrary();

//Create a LogMessage
LogMessage logMessage = new LogMessage()
            {
                Time = DateTime.Now.ToString(),
                Severity = severity,
                Text = message
            };

// Log a debug message
logger.Log(SeverityType.Debug, "This is a debug message");

// Log a warning message
logger.Log(SeverityType.Warning, "This is a warning message");

// Log an error message
logger.Log(SeverityType.Error, "This is an error message");


You can customize the LoggingLibrary in a few ways. You can modify the following properties of the "LoggingLibrary" class to customize the behavior:

    - LogFilePath: Specifies the path of the log file. By Default, the log file is created in the same directory as the executable file of your application.
    - LogFormat:   Specifies the format of the log messages. By default, the log messages are formatted as '[yyyy-MM-dd HH:mm:ss] - [LogLevel] - Message.'
    - LogLevelThreshold: Specifies the minimum log level the will be written to the file. By default, Debug logs are not written to the file.


Example: 

    LoggingLibrary library = new LoggingLibrary() {
        LogFilePath = @"C:\Logs\logs.log",
        LogFormat = "[{LogLevel} {Message}]",
        LogLevelThreshold = SeverityType.Warning
    }
