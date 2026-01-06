
namespace ToDo.BackEnd
{
    public class CustomLogger : ILogger
    {
        #region Fields
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;
        #endregion

        #region Constructor
        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            loggerName = name;
            loggerConfig = config;
        }
        #endregion

        #region Members
        private void WriteLogToTheFile(string message)
        {
            string pathFile = @"c:\logs\ToDo_log.txt";

            using (StreamWriter sw = new StreamWriter(pathFile, true))
            {
                try
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion

        #region ILogger Interface
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()}: {eventId} - {formatter(state, exception)}";

            WriteLogToTheFile(message);
        }
        #endregion

    }
}
