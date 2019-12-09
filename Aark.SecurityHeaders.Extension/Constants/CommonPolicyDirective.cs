using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// Common directives.
    /// </summary>
    public static class CommonPolicyDirective
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

        internal const string ReportUri = "report-uri";
    }

    internal static class DirectiveHelper
    {
        internal const string AllowAll = "{0} *";
        internal const string AllowSelf = "{0} 'self'";
        internal const string AllowSrc = "{0} 'src'";
        internal const string DenyAll = "{0} 'none'";
        internal const string AllowOrigin = "{0}";

        public static string ToFormatedString(this CommonPolicyDirective.Directive directive)
        {
            return directive switch
            {
                CommonPolicyDirective.Directive.AllowAll => AllowAll,
                CommonPolicyDirective.Directive.AllowSelf => AllowSelf,
                CommonPolicyDirective.Directive.AllowSrc => AllowSrc,
                CommonPolicyDirective.Directive.DenyAll => DenyAll,
                CommonPolicyDirective.Directive.AllowOrigin => AllowOrigin,
                _ => DenyAll,
            };
        }
    }

}
