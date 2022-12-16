using System.Runtime.Serialization;

namespace WetherViewer.Service.Exceptions
{
    internal class CountryNotFound : Exception
    {
        public CountryNotFound()
        {
        }

        public CountryNotFound(string message) : base(message)
        {
        }

        public CountryNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CountryNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}