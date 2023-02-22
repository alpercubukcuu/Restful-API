using Newtonsoft.Json;
using RestfulAPI_Example.Services;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace RestfulAPI_Example.MiddleWares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerServices _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerServices loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + " ms ";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
          
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message : " + ex.Message + " in " + watch.ElapsedMilliseconds + " ms ";
            _loggerService.Write(message);

           

            var result = JsonConvert.SerializeObject(new { Err = ex.Message } , Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this ApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        
        }
    }
}
