using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeighingManager.Helpers;

namespace WeighingManager.Models
{
    public class WeighingSummary
    {
        [JsonProperty("scale_id")]
        public string ScaleId { get; set; }

        [JsonProperty("truck_id")]
        public string TruckId { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }
    }
}
