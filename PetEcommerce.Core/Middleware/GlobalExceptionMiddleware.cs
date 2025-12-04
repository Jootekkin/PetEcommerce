using Microsoft.AspNetCore.Http;

namespace PetEcommerce.Core.Middleware
{
    public class GlobalExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructors
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = ex.Message;
                await context.Response.WriteAsync(response);
            }
        }
        #endregion
    }
}
