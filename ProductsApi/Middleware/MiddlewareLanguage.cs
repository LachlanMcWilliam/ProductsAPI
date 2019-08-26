using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BandQ.Commons.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ProductsApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLanguage
    {
        private readonly RequestDelegate _next;

        public MiddlewareLanguage(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IProductService service)
        {
            var language = httpContext.Request.Query["language"];

            if (!String.IsNullOrWhiteSpace(language))
            {
                var culture = new CultureInfo(language);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                var products = await service.GetProducts();
                await _next(httpContext);
            }
            else
            {
                await httpContext.Response.WriteAsync("There is no culture assigned");
            }


            

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLanguageExtensions
    {
        public static IApplicationBuilder UseMiddlewareLanguage(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLanguage>();
        }
    }
}
