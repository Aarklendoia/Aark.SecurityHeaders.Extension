using System;
using System.Collections.Generic;
using System.Text;

namespace Aark.SecurityHeaders.Extension.Constants
{
    /// <summary>
    /// Common scheme source.
    /// </summary>
    public static class CommonPolicySchemeSource
    {
        /// <summary>
        /// A schema such as 'http:' or 'https:'.
        /// </summary>
        [Flags]
        public enum SchemeSources
        {
            /// <summary>
            /// No scheme define.
            /// </summary>
            None = 1,
            /// <summary>
            ///  Allows data: URIs to be used as a content source. This is insecure; an attacker can also inject arbitrary data: URIs. Use this sparingly and definitely not for scripts.
            /// </summary>
            Data = 2,
            /// <summary>
            ///  Allows mediastream: URIs to be used as a content source.
            /// </summary>
            MediaStream = 4,
            /// <summary>
            /// blob: Allows blob: URIs to be used as a content source.
            /// </summary>
            Blob = 8,
            /// <summary>
            /// Allows filesystem: URIs to be used as a content source.
            /// </summary>
            FileSystem = 16
        }
    }

    internal static class SchemeSourceHelper
    {
        internal const string None = "";
        internal const string Data = "data:";
        internal const string MediaStream = "mediastream:";
        internal const string Blob = "blob:";
        internal const string FileSystem = "filesystem:";

        public static string ToFormatedString(this CommonPolicySchemeSource.SchemeSources schemeSource)
        {
            return schemeSource switch
            {
                CommonPolicySchemeSource.SchemeSources.Data => Data,
                CommonPolicySchemeSource.SchemeSources.MediaStream => MediaStream,
                CommonPolicySchemeSource.SchemeSources.Blob => Blob,
                CommonPolicySchemeSource.SchemeSources.FileSystem => FileSystem,
                _ => None,
            };
        }
    }
}
