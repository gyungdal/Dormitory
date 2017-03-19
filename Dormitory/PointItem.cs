using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dormitory {
    class PointItem {
        [JsonProperty("school_num")]
        string school_num { get; set; }
        [JsonProperty("name")]
        string name { get; set; }
        [JsonProperty("plus")]
        int plus { get; set; }
        [JsonProperty("minus")]
        int minus { get; set; }
        [JsonProperty("phone_number")]
        string phone_number { get; set; }
    }
}