using System;

namespace MRZ.Exceptions
{
    [Serializable]
    public class UnsupportedMRZException : Exception
    {
        public UnsupportedMRZException()
        {
        }

        public UnsupportedMRZException(string message)
            : base(message)
        {
        }

        public UnsupportedMRZException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UnsupportedMRZException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}