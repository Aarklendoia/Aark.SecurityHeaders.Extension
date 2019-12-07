using System.Collections.Generic;

namespace Aark.SecurityHeaders.Extension
{
    /// <summary>
    /// Security headers policy.
    /// </summary>
    public class SecurityHeadersPolicy
    {
        internal IDictionary<string, string> SetHeaders { get; } = new Dictionary<string, string>();

        internal ISet<string> RemoveHeaders { get; } = new HashSet<string>();
    }
}
