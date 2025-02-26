
using Airline.Domain.Exceptions;

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
            catch (Domain.Exceptions.NotFoundException ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("NotFound");
            }
            catch(OwnershipException ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You do not own this entity");
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
