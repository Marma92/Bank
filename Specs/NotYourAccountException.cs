using System;
using System.Runtime.Serialization;

namespace bankdata.Services
{
    [Serializable]
    public class NotYourAccountException : Exception
    {
        public NotYourAccountException()
        {
        }

        public NotYourAccountException(string message) : base(message)
        {
        }

        public NotYourAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotYourAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}