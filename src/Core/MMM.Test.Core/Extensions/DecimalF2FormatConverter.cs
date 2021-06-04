using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MMM.Test.Core.Extensions
{
    public class DecimalF2FormatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(double) || objectType == typeof(double?));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToDecimal(value).ToString("F2", CultureInfo.InvariantCulture)); 
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value;
        }
    }
}
