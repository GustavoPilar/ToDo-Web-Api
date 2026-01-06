using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDo.BackEnd
{
    public class LoggingFilter : IActionFilter
    {

        #region Fields
        private readonly ILogger<LoggingFilter> _logger;
        #endregion

        #region Constructor
        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }
        #endregion

        #region IActionFilter Interface

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Before actions
            _logger.LogInformation("### Executando DEPOIS dos métodos de ação ###");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("### Executando ANTES dos métods de ação ###");
        }
        #endregion
    }
}
