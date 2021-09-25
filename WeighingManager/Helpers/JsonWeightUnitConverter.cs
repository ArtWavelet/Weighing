using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeighingManager.Models;

namespace WeighingManager.Helpers
{
    public class JsonWeightUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(WeightUnit), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WeightUnit messageTransportResponseStatus = (WeightUnit)value;

            switch (messageTransportResponseStatus)
            {
                case WeightUnit.kg:
                    writer.WriteValue("kg");
                    break;
                case WeightUnit.pound:
                    writer.WriteValue("pound");
                    break;
                case WeightUnit.ton:
                    writer.WriteValue("ton");
                    break;

            }
        }
    }
}
