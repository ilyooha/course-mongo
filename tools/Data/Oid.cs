using Newtonsoft.Json;

namespace Data
{
    public class Oid
    {
        [JsonProperty("$oid")]
        public string Value { get; set; }
    }
}