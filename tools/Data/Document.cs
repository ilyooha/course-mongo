using Newtonsoft.Json;

namespace Data
{
    public class Document
    {
        [JsonProperty("_id")]
        public Oid Id { get; set; }
    }
}