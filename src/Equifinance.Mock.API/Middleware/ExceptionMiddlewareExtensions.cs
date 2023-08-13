
using Equifinance.Mock.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace Equifinance.Mock.API.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureBuiltInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFearute = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    context.Response.ContentType = "application/json";

                    if (contextFearute != null && contextRequest != null)
                    {
                        var errorString = new ErrorResponseData()
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Message = contextFearute.Error.Message,
                            Path = contextRequest.Path
                        }.ToString();

                        await context.Response.WriteAsync(errorString);
                    }
                });
            });
        }
        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
