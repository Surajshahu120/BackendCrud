using System.Net;

namespace CrudBackend.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ErrorHandlingMiddleware(RequestDelegate requestDelegate)
        {
              _requestDelegate=requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var errorResponse = new { status="500", message = ex.Message };
                    await context.Response.WriteAsJsonAsync(errorResponse);
                }
            }
        }
    }
}
