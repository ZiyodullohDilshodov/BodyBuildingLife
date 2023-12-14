using BodyBuildingLife.Api.Helpers;
using BodyBuildingLife.Service.Exceptions;

namespace BodyBuildingLife.Api.Middlewares
{
    public class ExceptionHendlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHendlerMiddleware> _logger;
        private  long logNumber =0;
        public ExceptionHendlerMiddleware(RequestDelegate next, ILogger<ExceptionHendlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task  Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BodyBuildingLifeException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Responses
                {
                    Code = ex.StatusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"{++logNumber}:\t{ex.Message}\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Responses
                {
                    Code = 500,
                    Message = ex.Message
                });
            }
        }
    }
}
