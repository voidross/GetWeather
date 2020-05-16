using Newtonsoft.Json;

namespace GetWeather_console
{
    public class Wind
    {
        [JsonProperty("speed")]
        public float Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
}