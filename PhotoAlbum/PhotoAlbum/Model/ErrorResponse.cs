using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Model
{
    /// <summary>
    /// ErrorResponse
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// StackTrace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// ErrorResponse
        /// </summary>
        /// <param name="ex"></param>
        public ErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
        }
    }
}
