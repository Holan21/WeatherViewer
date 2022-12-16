using System.Runtime.Serialization;

namespace WetherViewer.Service.Exceptions
{
    internal class CityNotFound : Exception
    {
        public CityNotFound()
        {
        }

        public CityNotFound(string message) : base(message)
        {
        }

        public CityNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CityNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
