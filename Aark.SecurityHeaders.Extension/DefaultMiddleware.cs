using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Aark.SecurityHeaders.Extension
{
    /// <summary>
    /// Default middleware for the extensions.
    /// </summary>
    public class DefaultMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="next"></param>
        public DefaultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            await _next(context).ConfigureAwait(false);
        }
    }
}
