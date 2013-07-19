using System;
using GrooveSharp.DataTransferObjects;

namespace GrooveSharp.Exceptions
{
    public class GrooveException : Exception
    {
        public int Code { get; set; }

        public GrooveException(string message, int code) : base(message)
        {
            this.Code = code;
        }

        public GrooveException(string message, int code, Exception innerException)
            : base(message, innerException)
        {
            this.Code = code;
        }

        internal GrooveException(Fault fault) : this(fault.Message, fault.Code)
        {
        }
    }
}
