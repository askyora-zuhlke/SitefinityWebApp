using Newtonsoft.Json;

namespace SitefinityWebApp.Dto
{


    public partial class Psi
    {
        [JsonProperty("region_metadata")]
        public RegionMetadatum[] RegionMetadata { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("api_info")]
        public ApiInfo ApiInfo { get; set; }
    }

    public partial class ApiInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("update_timestamp")]
        public DateTimeOffset UpdateTimestamp { get; set; }

        [JsonProperty("readings")]
        public Dictionary<string, Reading> Readings { get; set; }
    }

    public partial class Reading
    {
        [JsonProperty("west")]
        public double West { get; set; }

        [JsonProperty("national")]
        public double National { get; set; }

        [JsonProperty("east")]
        public double East { get; set; }

        [JsonProperty("central")]
        public double Central { get; set; }

        [JsonProperty("south")]
        public double South { get; set; }

        [JsonProperty("north")]
        public double North { get; set; }
    }

    public partial class RegionMetadatum
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label_location")]
        public LabelLocation LabelLocation { get; set; }
    }

    public partial class LabelLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
