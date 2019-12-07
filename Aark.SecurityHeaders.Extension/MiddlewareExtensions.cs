using Microsoft.AspNetCore.Builder;
using System;

namespace Aark.SecurityHeaders.Extension
{
    /// <summary>
    /// Middleware extensions.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Add security headers.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            SecurityHeadersPolicy policy = builder.Build();
            return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        }
    }
}
