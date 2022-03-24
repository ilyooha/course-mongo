using Newtonsoft.Json;

namespace Data.Products.Models
{
    public class SodaDrink : Product
    {
        [JsonProperty("volume_ml")]
        public int VolumeMl { get; set; }

        public SodaDrink()
        {
            Type = "soda drink";
        }
    }
}