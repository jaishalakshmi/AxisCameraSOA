using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AxiscamWeb.Models
{
    public class CamLogData
    {
        [JsonProperty(PropertyName = "DetectedTime")]
        public DateTime DetectedTime { get; set; }
        [JsonProperty(PropertyName = "IsDetected")]
        public bool IsDetected { get; set; }
    }
}