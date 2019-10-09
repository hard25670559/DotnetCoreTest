using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore_30_Middleware_Test.MiddlewareExtensions
{
    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseTest(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleware>();
        }
    }


    public class TestMiddleware
    {
        private readonly RequestDelegate Next;

        public TestMiddleware(RequestDelegate next)
        {
            this.Next = next;
        }

        // IMyScopedService is injected into Invoke
        public async Task Invoke(HttpContext httpContext)
        {
            Debug.WriteLine("Test in\n");
            await this.Next(httpContext);
            Debug.WriteLine("Test out\n");
        }
    }
}
