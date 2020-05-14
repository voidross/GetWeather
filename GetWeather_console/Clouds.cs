using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; private set; }

        public Clouds(JToken clouds)
        {
            if (clouds.SelectToken("all") is null)
                All = -1;
            else
                All = int.Parse(clouds.SelectToken("all").ToString());
        }
    }
}
