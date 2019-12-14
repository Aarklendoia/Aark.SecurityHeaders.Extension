using System;
using System.Runtime.Serialization;

namespace Aark.SecurityHeaders.Extension.Exceptions
{
    /// <summary>
    /// Occurs when the report uri is mandatory but not available.
    /// </summary>
    [Serializable]
    public class ReportUriMissingException : Exception
    {
        /// <summary>
        /// Create a new ReportUriMissingException.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Ne pas passer de littéraux en paramètres localisés", Justification = "<En attente>")]
        public ReportUriMissingException()
            : base("The report URI is missing. Call AddReportUri or assign the value false to the reportOnly parameter")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ReportUriMissingException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ReportUriMissingException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ReportUriMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
