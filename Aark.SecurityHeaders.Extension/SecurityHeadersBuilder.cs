using Aark.SecurityHeaders.Extension.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Aark.SecurityHeaders.Extension
{
    /// <summary>
    /// Exposes methods to build a policy.
    /// </summary>
    public class SecurityHeadersBuilder
    {
        private Uri _reportUri = null;

        private readonly SecurityHeadersPolicy _policy = new SecurityHeadersPolicy();
        private readonly Dictionary<FeaturePolicyConstants.HttpFeatures, CommonPolicyDirective.Directive> _features = new Dictionary<FeaturePolicyConstants.HttpFeatures, CommonPolicyDirective.Directive>();
        private readonly Dictionary<ContentSecurityPolicyConstants.FetchDirectives, CommonPolicyDirective.Directive> _directives = new Dictionary<ContentSecurityPolicyConstants.FetchDirectives, CommonPolicyDirective.Directive>();

        /// <summary>
        /// The number of seconds in one year
        /// </summary>
        public const int OneYearInSeconds = 60 * 60 * 24 * 365;

        /// <summary>
        /// Add default headers in accordance with most secure approach
        /// </summary>
        public SecurityHeadersBuilder AddDefaultSecurePolicy()
        {
            AddFrameOptionsDeny();
            AddXssProtectionBlock();
            AddContentTypeOptionsNoSniff();
            AddStrictTransportSecurityMaxAge();
            RemoveServerHeader();
            AddReferrerPolicy();
            ClearFeaturePolicy();
            ClearContentSecurityPolicy();
            return this;
        }

        private SecurityHeadersBuilder ClearFeaturePolicy()
        {
            _features.Clear();
            return this;
        }

        private SecurityHeadersBuilder ClearContentSecurityPolicy()
        {
            _directives.Clear();
            return this;
        }

        /// <summary>
        /// Add a report uri.
        /// </summary>
        /// <param name="reportUri">Uri where to report rule violations.</param>
        /// <returns></returns>
        public SecurityHeadersBuilder AddReportUri(Uri reportUri)
        {
            _reportUri = reportUri;
            return this;
        }

        /// <summary>
        /// Adds a list of features to which the provided directive is applied.
        /// </summary>
        /// <param name="directive">Directive to apply.</param>
        /// <param name="features">Features.</param>
        /// <param name="hostSources">List of source uri if the directive requires one.</param>
        /// <returns></returns>
        public SecurityHeadersBuilder AddFeaturePolicy(CommonPolicyDirective.Directive directive, FeaturePolicyConstants.HttpFeatures features, IList<Uri> hostSources = null)
        {
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Accelerometer))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Accelerometer, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.AmbientLightSensor))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.AmbientLightSensor, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Autoplay))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Autoplay, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Battery))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Battery, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Camera))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Camera, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.DisplayCapture))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.DisplayCapture, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.DocumentDomain))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.DocumentDomain, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.EncryptedMedia))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.EncryptedMedia, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.ExecutionWhileNotRendered))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.ExecutionWhileNotRendered, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.ExecutionWhileOutOfViewport))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.ExecutionWhileOutOfViewport, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Fullscreen))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Fullscreen, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Geolocation))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Geolocation, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Gyroscope))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Gyroscope, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Magnetometer))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Magnetometer, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Microphone))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Microphone, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Midi))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Midi, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Payment))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Payment, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.PictureInPicture))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.PictureInPicture, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.PublickeyCredentials))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.PublickeyCredentials, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Speaker))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Speaker, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.SyncXhr))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.SyncXhr, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.Usb))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.Usb, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.WakeLock))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.WakeLock, directive);
            if (features.HasFlag(FeaturePolicyConstants.HttpFeatures.XrSpatialTracking))
                _features.TryAdd(FeaturePolicyConstants.HttpFeatures.XrSpatialTracking, directive);
            _policy.SetHeaders[FeaturePolicyConstants.Header] = FeaturesToString(hostSources);
            return this;
        }

        private string FeaturesToString(IList<Uri> hostSources = null)
        {
            string value = null;
            foreach (KeyValuePair<FeaturePolicyConstants.HttpFeatures, CommonPolicyDirective.Directive> feature in _features)
            {
                if (value == null)
                    value = string.Format(CultureInfo.InvariantCulture, feature.Value.ToFormatedString(), feature.Key.ToFormatedString());
                else
                    value += "; " + string.Format(CultureInfo.InvariantCulture, feature.Value.ToFormatedString(), feature.Key.ToFormatedString());
            }
            if (hostSources != null)
            {
                string urls = string.Empty;
                foreach (Uri url in hostSources)
                {
                    urls += " " + url.AbsoluteUri;
                }
                return value + urls;
            }
            return value;
        }

        /// <summary>
        /// Adds a list of content security to which the provided directive is applied.
        /// </summary>
        /// <param name="directive">Directive to apply.</param>
        /// <param name="fetchDirective">Content security fetch directive.</param>
        /// <param name="hostSources">List of uri if the directive requires one.</param>
        /// <param name="schemeSources">List of scheme source authorized.</param>
        /// <returns></returns>
        public SecurityHeadersBuilder AddContentSecurityPolicy(CommonPolicyDirective.Directive directive, ContentSecurityPolicyConstants.FetchDirectives fetchDirective, CommonPolicySchemeSource.SchemeSources schemeSources, IList<Uri> hostSources = null)
        {
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ChildSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ChildSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ConnectSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ConnectSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.DefaultSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.DefaultSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.FontSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.FontSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.FrameSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.FrameSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ImgSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ImgSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ManifestSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ManifestSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.MediaSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.MediaSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ObjectSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ObjectSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.PrefetchSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.PrefetchSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrc, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrcAttr))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrcAttr, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrcElem))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.ScriptSrcElem, directive);
            if (fetchDirective.HasFlag(ContentSecurityPolicyConstants.FetchDirectives.WorkerSrc))
                _directives.TryAdd(ContentSecurityPolicyConstants.FetchDirectives.WorkerSrc, directive);
            string header = ContentSecurityToString(hostSources);
            header += SchemeSourceToString(schemeSources);
            if (_reportUri != null)
            {
                header += "; " + CommonPolicyDirective.ReportUri + " " + _reportUri.AbsoluteUri;
            }
            _policy.SetHeaders[ContentSecurityPolicyConstants.Header] = header;
            return this;
        }

        private string ContentSecurityToString(IList<Uri> hostSources = null)
        {
            string value = null;
            foreach (KeyValuePair<ContentSecurityPolicyConstants.FetchDirectives, CommonPolicyDirective.Directive> directive in _directives)
            {
                if (value == null)
                    value = string.Format(CultureInfo.InvariantCulture, directive.Value.ToFormatedString(), directive.Key.ToFormatedString());
                else
                    value += "; " + string.Format(CultureInfo.InvariantCulture, directive.Value.ToFormatedString(), directive.Key.ToFormatedString());
            }
            if (hostSources != null)
            {
                string urls = string.Empty;
                foreach (Uri url in hostSources)
                {
                    urls += " " + url.AbsoluteUri;
                }
                return value + urls;
            }
            return value;
        }

        private static string SchemeSourceToString(CommonPolicySchemeSource.SchemeSources schemeSources)
        {
            if (schemeSources.HasFlag(CommonPolicySchemeSource.SchemeSources.None))
                return null;
            List<CommonPolicySchemeSource.SchemeSources> schemeSourceList = new List<CommonPolicySchemeSource.SchemeSources>();
            if (schemeSources.HasFlag(CommonPolicySchemeSource.SchemeSources.Blob))
                schemeSourceList.Add(CommonPolicySchemeSource.SchemeSources.Blob);
            if (schemeSources.HasFlag(CommonPolicySchemeSource.SchemeSources.Data))
                schemeSourceList.Add(CommonPolicySchemeSource.SchemeSources.Data);
            if (schemeSources.HasFlag(CommonPolicySchemeSource.SchemeSources.FileSystem))
                schemeSourceList.Add(CommonPolicySchemeSource.SchemeSources.FileSystem);
            if (schemeSources.HasFlag(CommonPolicySchemeSource.SchemeSources.MediaStream))
                schemeSourceList.Add(CommonPolicySchemeSource.SchemeSources.MediaStream);
            string value = null;
            foreach (CommonPolicySchemeSource.SchemeSources schemeSource in schemeSourceList)
            {
                value += " " + schemeSource.ToFormatedString();
            }
            return value;
        }

        private SecurityHeadersBuilder AddReferrerPolicy()
        {
            _policy.SetHeaders[ReferrerPolicyConstants.Header] = ReferrerPolicyConstants.StrictOriginWhenCrossOrigin;
            return this;
        }

        /// <summary>
        /// Add X-Frame-Options DENY to all requests.
        /// The page cannot be displayed in a frame, regardless of the site attempting to do so
        /// </summary>
        public SecurityHeadersBuilder AddFrameOptionsDeny()
        {
            _policy.SetHeaders[FrameOptionsConstants.Header] = FrameOptionsConstants.Deny;
            return this;
        }

        /// <summary>
        /// Add X-Frame-Options SAMEORIGIN to all requests.
        /// The page can only be displayed in a frame on the same origin as the page itself.
        /// </summary>
        public SecurityHeadersBuilder AddFrameOptionsSameOrigin()
        {
            _policy.SetHeaders[FrameOptionsConstants.Header] = FrameOptionsConstants.SameOrigin;
            return this;
        }

        /// <summary>
        /// Add X-Frame-Options ALLOW-FROM {uri} to all requests, where the uri is provided
        /// The page can only be displayed in a frame on the specified origin.
        /// </summary>
        /// <param name="uri">The uri of the origin in which the page may be displayed in a frame</param>
        public SecurityHeadersBuilder AddFrameOptionsSameOrigin(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            _policy.SetHeaders[FrameOptionsConstants.Header] = string.Format(CultureInfo.InvariantCulture, FrameOptionsConstants.AllowFromUri, uri.ToString());
            return this;
        }


        /// <summary>
        /// Add X-XSS-Protection 1 to all requests.
        /// Enables the XSS Protections
        /// </summary>
        public SecurityHeadersBuilder AddXssProtectionEnabled()
        {
            _policy.SetHeaders[XssProtectionConstants.Header] = XssProtectionConstants.Enabled;
            return this;
        }

        /// <summary>
        /// Add X-XSS-Protection 0 to all requests.
        /// Disables the XSS Protections offered by the user-agent.
        /// </summary>
        public SecurityHeadersBuilder AddXssProtectionDisabled()
        {
            _policy.SetHeaders[XssProtectionConstants.Header] = XssProtectionConstants.Disabled;
            return this;
        }

        /// <summary>
        /// Add X-XSS-Protection 1; mode=block to all requests.
        /// Enables XSS protections and instructs the user-agent to block the response in the event that script has been inserted from user input, instead of sanitizing.
        /// </summary>
        public SecurityHeadersBuilder AddXssProtectionBlock()
        {
            _policy.SetHeaders[XssProtectionConstants.Header] = XssProtectionConstants.Block;
            return this;
        }

        /// <summary>
        /// Add X-XSS-Protection 1; report=http://site.com/report to all requests.
        /// A partially supported directive that tells the user-agent to report potential XSS attacks to a single URL. Data will be POST'd to the report URL in JSON format.
        /// </summary>
        public SecurityHeadersBuilder AddXssProtectionReport(Uri reportUrl)
        {
            if (reportUrl == null)
            {
                throw new ArgumentNullException(nameof(reportUrl));
            }

            _policy.SetHeaders[XssProtectionConstants.Header] =
                string.Format(CultureInfo.InvariantCulture, XssProtectionConstants.Report, reportUrl.ToString());
            return this;
        }

        /// <summary>
        /// Add Strict-Transport-Security max-age=<see cref="int"/> to all requests.
        /// Tells the user-agent to cache the domain in the STS list for the number of seconds provided.
        /// </summary>
        public SecurityHeadersBuilder AddStrictTransportSecurityMaxAge(int maxAge = OneYearInSeconds)
        {
            _policy.SetHeaders[StrictTransportSecurityConstants.Header] =
                string.Format(CultureInfo.InvariantCulture, StrictTransportSecurityConstants.MaxAge, maxAge);
            return this;
        }

        /// <summary>
        /// Add Strict-Transport-Security max-age=<see cref="int"/>; includeSubDomains to all requests.
        /// Tells the user-agent to cache the domain in the STS list for the number of seconds provided and include any sub-domains.
        /// </summary>
        public SecurityHeadersBuilder AddStrictTransportSecurityMaxAgeIncludeSubDomains(int maxAge = OneYearInSeconds)
        {
            _policy.SetHeaders[StrictTransportSecurityConstants.Header] =
                string.Format(CultureInfo.InvariantCulture, StrictTransportSecurityConstants.MaxAgeIncludeSubdomains, maxAge);
            return this;
        }

        /// <summary>
        /// Add Strict-Transport-Security max-age=0 to all requests.
        /// Tells the user-agent to remove, or not cache the host in the STS cache
        /// </summary>
        public SecurityHeadersBuilder AddStrictTransportSecurityNoCache()
        {
            _policy.SetHeaders[StrictTransportSecurityConstants.Header] =
                StrictTransportSecurityConstants.NoCache;
            return this;
        }

        /// <summary>
        /// Add X-Content-Type-Options nosniff to all requests.
        /// Can be set to protect against MIME type confusion attacks.
        /// </summary>
        public SecurityHeadersBuilder AddContentTypeOptionsNoSniff()
        {
            _policy.SetHeaders[ContentTypeOptionsConstants.Header] = ContentTypeOptionsConstants.NoSniff;
            return this;
        }

        /// <summary>
        /// Removes the Server header from all responses
        /// </summary>
        public SecurityHeadersBuilder RemoveServerHeader()
        {
            _policy.RemoveHeaders.Add(ServerConstants.Header);
            return this;
        }

        /// <summary>
        /// Adds a custom header to all requests
        /// </summary>
        /// <param name="header">The header name</param>
        /// <param name="value">The value for the header</param>
        /// <returns></returns>
        public SecurityHeadersBuilder AddCustomHeader(string header, string value)
        {
            if (string.IsNullOrEmpty(header))
            {
                throw new ArgumentNullException(nameof(header));
            }

            _policy.SetHeaders[header] = value;
            return this;
        }

        /// <summary>
        /// Remove a header from all requests
        /// </summary>
        /// <param name="header">The to remove</param>
        /// <returns></returns>
        public SecurityHeadersBuilder RemoveHeader(string header)
        {
            if (string.IsNullOrEmpty(header))
            {
                throw new ArgumentNullException(nameof(header));
            }

            _policy.RemoveHeaders.Add(header);
            return this;
        }

        /// <summary>
        /// Builds a new <see cref="SecurityHeadersPolicy"/> using the entries added.
        /// </summary>
        /// <returns>The constructed <see cref="SecurityHeadersPolicy"/>.</returns>
        public SecurityHeadersPolicy Build()
        {
            return _policy;
        }
    }
}
