using System.Collections.Concurrent;

namespace ToDo.BackEnd
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        #region Fields
        readonly CustomLoggerProviderConfiguration _loggerConfig;
        readonly ConcurrentDictionary<string, CustomLogger> loggers = new ConcurrentDictionary<string, CustomLogger>();
        #endregion

        #region Constructor
        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerConfig = loggerConfig;
        }
        #endregion

        public ILogger CreateLogger(string categoryName) // => Cria e/ou retorna o logger de acordo com a categoria
        {
            return loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
        }

        public void Dispose() // => Quando discartar
        {
            loggers.Clear();
        }
    }
}
