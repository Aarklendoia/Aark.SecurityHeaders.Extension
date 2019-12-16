using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks (XSS).
    /// </summary>
    public static partial class ContentSecurityPolicyConstants
    {
        /// <summary>
        /// Header value for Content-Security-Policy.
        /// </summary>
        public static readonly string Header = "Content-Security-Policy";

        /// <summary>
        /// Header value for Content-Security-Policy-Report-Only.
        /// </summary>
        public static readonly string HeaderReportOnly = "Content-Security-Policy-Report-Only";
    }
}
