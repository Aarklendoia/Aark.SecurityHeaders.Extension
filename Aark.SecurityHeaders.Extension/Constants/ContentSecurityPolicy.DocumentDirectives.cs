using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// Document directives govern the properties of a document or worker environment to which a policy applies.
    /// </summary>
    public partial class ContentSecurityPolicy
    {
        /// <summary>
        /// List of Content Security Policy Document directives.
        /// </summary>
        public enum DocumentDirectives
        {
            /// <summary>
            /// Restricts the URLs which can be used in a document's base element.
            /// </summary>
            BaseUri,
            /// <summary>
            /// Restricts the set of plugins that can be embedded into a document by limiting the types of resources which can be loaded.
            /// </summary>
            PluginTypes,
            /// <summary>
            /// Enables a sandbox for the requested resource similar to the iframe sandbox attribute.
            /// </summary>
            Sandbox
        }
    }

    internal static class DirectiveHelper
    {
        internal const string BaseUri = "base-uri";
        internal const string PluginTypes = "plugin-types";
        internal const string Sandbox = "sandbox";

        public static string ToFormatedString(this ContentSecurityPolicy.DocumentDirectives directive)
        {
            return directive switch
            {
                ContentSecurityPolicy.DocumentDirectives.BaseUri => BaseUri,
                ContentSecurityPolicy.DocumentDirectives.PluginTypes => PluginTypes,
                ContentSecurityPolicy.DocumentDirectives.Sandbox => Sandbox,
                _ => BaseUri
            };
        }
    }
}
