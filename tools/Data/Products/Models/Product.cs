using Newtonsoft.Json;

namespace Data.Products.Models
{
    public abstract class Product: Document
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("nutrition facts")]
        public NutritionFacts NutritionFacts { get; set; } = new();
    }
}