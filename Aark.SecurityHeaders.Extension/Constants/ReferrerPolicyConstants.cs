namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// Constants for the Referrer Policy.
    /// </summary>
    public static class ReferrerPolicyConstants
    {
        /// <summary>
        /// Header value for Referrer-Policy
        /// </summary>
        public static readonly string Header = "Referrer-Policy";

        /// <summary>
        /// The Referer header will be omitted entirely. No referrer information is sent along with requests
        /// </summary>
        public static readonly string NoReferrer = "no-referrer";

        /// <summary>
        /// This is the default behavior if no policy is specified, or if the provided value is invalid. The origin, path, and querystring of the URL are sent as a referrer 
        /// when the protocol security level stays the same (HTTP→HTTP, HTTPS→HTTPS) or improves (HTTP→HTTPS), but isn't sent to less secure destinations (HTTPS→HTTP).
        /// </summary>
        public static readonly string NoReferrerWhenDowngrade = "no-referrer-when-downgrade";

        /// <summary>
        /// Only send the origin of the document as the referrer.
        /// For example, a document at https://example.com/page.html will send the referrer https://example.com/.
        /// </summary>
        public static readonly string Origin = "origin";

        /// <summary>
        /// Send the origin, path, and query string when performing a same-origin request, but only send the origin of the document for other cases.
        /// </summary>
        public static readonly string OriginWhenCrossOrigin = "origin-when-cross-origin";

        /// <summary>
        /// A referrer will be sent for same-site origins, but cross-origin requests will send no referrer information.
        /// </summary>
        public static readonly string SameOrigin = "same-origin";

        /// <summary>
        /// A referrer will be sent for same-site origins, but cross-origin requests will send no referrer information.
        /// </summary>
        public static readonly string StrictOrigin = "strict-origin";

        /// <summary>
        /// Send the origin, path, and query string when performing a same-origin request, but only send the origin of the document for other cases
        /// </summary>
        public static readonly string StrictOriginWhenCrossOrigin = "strict-origin-when-cross-origin";

        /// <summary>
        /// Send the origin, path, and query string when performing any request, regardless of security
        /// This policy will leak potentially-private information from HTTPS resource URLs to insecure origins. Carefully consider the impact of this setting.
        /// </summary>
        public static readonly string UnsafeUrl = "unsafe-url";
    }
}
