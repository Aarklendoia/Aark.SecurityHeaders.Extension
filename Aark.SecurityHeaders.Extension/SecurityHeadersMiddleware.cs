using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Aark.SecurityHeaders.Extension
{
    /// <summary>
    /// Security headers middleware for the extensions.
    /// </summary>
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SecurityHeadersPolicy _policy;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="policy"></param>
        public SecurityHeadersMiddleware(RequestDelegate next, SecurityHeadersPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        /// <summary>
        /// Invoke.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            IHeaderDictionary headers = context.Response.Headers;

            foreach (var headerValuePair in _policy.SetHeaders)
            {
                headers[headerValuePair.Key] = headerValuePair.Value;
            }

            foreach (var header in _policy.RemoveHeaders)
            {
                headers.Remove(header);
            }

            await _next(context).ConfigureAwait(false);
        }
    }
}
