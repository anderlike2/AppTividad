using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfApptividad.Models
{
    public class ResponseModel
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public string InternalMessage { set; get; }

        /// <summary>
        /// Constructor default
        /// </summary>
        /// <returns></returns>
        public ResponseModel() { }

        /// <summary>
        /// Constructor from ResponseModel
        /// </summary>
        /// <param name="Success">bool param</param>
        /// <param name="Message">string param</param>
        /// <param name="InternalMessage">string param</param>
        /// <returns></returns>
        public ResponseModel(bool Success, string Message, string InternalMessage)
        {
            this.Success = Success;
            this.Message = Message;
            this.InternalMessage = InternalMessage;
        }
    }
}