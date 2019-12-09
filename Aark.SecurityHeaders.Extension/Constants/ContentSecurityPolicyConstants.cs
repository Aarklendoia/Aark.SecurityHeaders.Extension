using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks (XSS).
    /// </summary>
    public partial class ContentSecurityPolicyConstants
    {

        /// <summary>
        /// Fetch directives control locations from which certain resource types may be loaded.
        /// </summary>
        public enum Directive
        {
            /// <summary>
            /// The feature will be allowed in this document, and all nested browsing contexts(iframes) regardless of their origin.
            /// </summary>
            AllowAll,
            /// <summary>
            /// The feature will be allowed in this document, and in all nested browsing contexts (iframes) in the same origin.
            /// </summary>
            AllowSelf,
            /// <summary>
            /// (In an iframe allow attribute only) The feature will be allowed in this iframe, as long as the document loaded into it comes from the same origin as the URL in the iframe's src attribute.
            /// </summary>
            AllowSrc,
            /// <summary>
            /// The feature is disabled in top-level and nested browsing contexts.
            /// </summary>
            DenyAll,
            /// <summary>
            /// The feature is allowed for specific origins(for example, https://example.com). Origins should be separated by a space.
            /// </summary>
            AllowOrigin
        }

        /// <summary>
        /// Header value for Content-Security-Policy
        /// </summary>
        public static readonly string Header = "Content-Security-Policy"; // TODO Liste des directives
    }
}
