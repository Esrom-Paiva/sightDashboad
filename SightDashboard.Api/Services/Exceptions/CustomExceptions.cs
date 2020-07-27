using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Services.Exceptions
{
    public class CustomExceptions: Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public CustomExceptions()
        {
        }
        public CustomExceptions(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            StatusCode = httpStatusCode;
        }

        public CustomExceptions(string message, Exception innerException, HttpStatusCode httpStatusCode) : base(message, innerException)
        {
            StatusCode = httpStatusCode;
        }
    }
}
