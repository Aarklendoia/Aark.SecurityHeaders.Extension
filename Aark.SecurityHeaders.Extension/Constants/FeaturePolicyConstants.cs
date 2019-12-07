namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// The HTTP Feature-Policy  header provides a mechanism to allow and deny the use of browser features in its own frame, and in content within any iframe elements in the document.
    /// </summary>
    public static partial class FeaturePolicyConstants
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
        /// Header value for Feature-Policy
        /// </summary>
        public const string Header = "Feature-Policy";
    }

    internal static class DirectiveHelper
    {
        internal const string AllowAll = "{0} *";
        internal const string AllowSelf = "{0} 'self'";
        internal const string AllowSrc = "{0} 'src'";
        internal const string DenyAll = "{0} 'none'";
        internal const string AllowOrigin = "{0}";

        public static string ToFormatedString(this FeaturePolicyConstants.Directive directive)
        {
            return directive switch
            {
                FeaturePolicyConstants.Directive.AllowAll => AllowAll,
                FeaturePolicyConstants.Directive.AllowSelf => AllowSelf,
                FeaturePolicyConstants.Directive.AllowSrc => AllowSrc,
                FeaturePolicyConstants.Directive.DenyAll => DenyAll,
                FeaturePolicyConstants.Directive.AllowOrigin => AllowOrigin,
                _ => DenyAll,
            };
        }
    }
}
