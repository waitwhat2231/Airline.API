
namespace Airline.API.Middlewares
{
    public class ExceptionHandlingMiddlewares(ILogger<ExceptionHandlingMiddlewares> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("SomethingWentWrong");
            }
        }
    }
}
