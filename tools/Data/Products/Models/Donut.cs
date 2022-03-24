using Newtonsoft.Json;

namespace Data.Products.Models
{
    public class Donut : Product
    {
        [JsonProperty("shell")]
        public bool Shell { get; set; }

        public Donut()
        {
            Type = "donut";
        }
    }
}