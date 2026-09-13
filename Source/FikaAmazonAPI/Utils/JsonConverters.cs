using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.Utils
{
    class Iso8601DateTimeConverter : IsoDateTimeConverter
    {
        public Iso8601DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        }
    }

    class Iso8601DateConverter : IsoDateTimeConverter
    {
        public Iso8601DateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }

    /// <summary>
    /// Amazon occasionally returns undocumented enum values. Treat those as null
    /// instead of failing deserialization of the entire response.
    /// </summary>
    public class StringEnumConverterIgnoreUnknown : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (JsonSerializationException)
            {
                if (Nullable.GetUnderlyingType(objectType) != null)
                    return null;

                return Activator.CreateInstance(objectType);
            }
        }
    }
}