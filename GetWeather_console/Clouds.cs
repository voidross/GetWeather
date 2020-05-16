using Newtonsoft.Json;

namespace GetWeather_console
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
