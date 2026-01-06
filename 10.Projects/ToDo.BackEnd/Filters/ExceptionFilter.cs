using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDo.BackEnd
{
    public class ExceptionFilter : IExceptionFilter
    {
        readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção não tratada: Status 500");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação: Status 500")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
