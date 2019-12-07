using Microsoft.AspNetCore.Builder;

namespace Aark.SecurityHeaders.Extension
{
    internal static class DefaultMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DefaultMiddleware>();
        }
    }
}
