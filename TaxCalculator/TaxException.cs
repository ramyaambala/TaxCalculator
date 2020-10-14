using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TaxSerices
{
    [Serializable]
    public class TaxException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public TaxError TaxError { get; set; }

        public TaxException()
        {
        }

        public TaxException(HttpStatusCode statusCode, TaxError taxjarError, string message) : base(message)
        {
            HttpStatusCode = statusCode;
            TaxError = taxjarError;
        }
    }
}
