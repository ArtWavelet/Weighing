using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeighingManager.Helpers;

namespace WeighingManager.Models
{
    public class WeightMeasurement
    {
        [JsonProperty("scale_id")]
        public string ScaleId { get; set; }

        [JsonProperty("truck_id")]
        public string TruckId { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonConverter(typeof(JsonWeightUnitConverter))]
        [JsonProperty("unit")]
        public WeightUnit Unit { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}
