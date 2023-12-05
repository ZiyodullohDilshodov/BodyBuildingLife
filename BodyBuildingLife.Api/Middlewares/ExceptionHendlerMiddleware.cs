using BodyBuildingLife.Api.Helpers;
using BodyBuildingLife.Service.Exceptions;

namespace BodyBuildingLife.Api.Middlewares
{
    public class ExceptionHendlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHendlerMiddleware(RequestDelegate next)
        {
            _next = next;
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
