using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    public static partial class ContentSecurityPolicyConstants
    {
        /// <summary>
        /// Fetch directives control locations from which certain resource types may be loaded.
        /// </summary>
        [Flags]
        public enum FetchDirectives
        {
            /// <summary>
            /// Defines the valid sources for web workers and nested browsing contexts loaded using elements such as frame and iframe.
            /// Instead of child-src, authors who wish to regulate nested browsing contexts and workers should use the frame-src and worker-src directives, respectively.
            /// </summary>
            ChildSrc = 1,
            /// <summary>
            /// Restricts the URLs which can be loaded using script interfaces.
            /// </summary>
            ConnectSrc = 2,
            /// <summary>
            /// Serves as a fallback for the other fetch directives.
            /// </summary>
            DefaultSrc = 4,
            /// <summary>
            /// Specifies valid sources for fonts loaded using @font-face.
            /// </summary>
            FontSrc = 8,
            /// <summary>
            /// Specifies valid sources for nested browsing contexts loading using elements such as frame and iframe.
            /// </summary>
            FrameSrc = 16,
            /// <summary>
            /// Specifies valid sources of images and favicons.
            /// </summary>
            ImgSrc = 32,
            /// <summary>
            /// Specifies valid sources of application manifest files.
            /// </summary>
            ManifestSrc = 64,
            /// <summary>
            /// Specifies valid sources for loading media using the audio, video and track elements.
            /// </summary>
            MediaSrc = 128,
            /// <summary>
            /// Specifies valid sources for the object, embed, and applet elements.
            /// Elements controlled by object-src are perhaps coincidentally considered legacy HTML elements and are not recieving new standardized features(such as the security attributes sandbox or allow for iframe). Therefore it is recommended to restrict this fetch-directive (e.g.explicitly set object-src 'none' if possible).
            /// </summary>
            ObjectSrc = 256,
            /// <summary>
            /// Specifies valid sources to be prefetched or prerendered.
            /// </summary>
            PrefetchSrc = 512,
            /// <summary>
            /// Specifies valid sources for JavaScript.
            /// </summary>
            ScriptSrc = 1024,
            /// <summary>
            /// Specifies valid sources for JavaScript script elements.
            /// </summary>
            ScriptSrcElem = 2048,
            /// <summary>
            /// Specifies valid sources for JavaScript inline event handlers.
            /// </summary>
            ScriptSrcAttr = 4096,
            /// <summary>
            /// Specifies valid sources for stylesheets.
            /// </summary>
            StyleSrc = 8192,
            /// <summary>
            /// Specifies valid sources for stylesheets style elements and link elements with rel="stylesheet".
            /// </summary>
            StyleSrcElem = 16384,
            /// <summary>
            /// Specifies valid sources for inline styles applied to individual DOM elements.
            /// </summary>
            StyleSrcAttr = 32768,
            /// <summary>
            /// Specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
            /// </summary>
            WorkerSrc = 65536
        }
    }
}
