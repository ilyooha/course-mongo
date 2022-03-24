using Newtonsoft.Json;

namespace Data.Products.Models
{
    public class NutritionFacts
    {
        [JsonProperty("fat")]
        public double Fat { get; set; }

        [JsonProperty("protein")]
        public double Protein { get; set; }

        [JsonProperty("carbs")]
        public double Carbs { get; set; }

        [JsonProperty("energy")]
        public double Energy { get; set; }
    }
}