using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    internal static class ExceptCTConstants
    {
        /// <summary>
        /// Header value for Expect-CT.
        /// </summary>
        public const string Header = "Expect-CT";

        /// <summary>
        /// Specifies the number of seconds after reception of the Expect-CT header field during which the user agent should regard the host from whom the message was received as a known Expect-CT host.
        /// If a cache receives a value greater than it can represent, or if any of its subsequent calculations overflows, the cache will consider the value to be either 2147483648 (2^31) or the greatest positive integer it can conveniently represent.
        /// </summary>
        public const string MaxAge = "max-age=";

        /// <summary>
        /// Signals to the user agent that compliance with the Certificate Transparency policy should be enforced (rather than only reporting compliance) and that the user agent should refuse future connections that violate its Certificate Transparency policy.
        /// When both the enforce directive and the report-uri directive are present, the configuration is referred to as an "enforce-and-report" configuration, signalling to the user agent both that compliance to the Certificate Transparency policy should be enforced and that violations should be reported.
        /// </summary>
        public const string Enforce = "enforce";
    }
}
