using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("main")]
        public string Main { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("icon")]
        public string Icon { get; private set; }

        public Weather(JToken weather)
        {
            if (weather.SelectToken("id") is null)
                Id = -1;
            else
                Id = int.Parse(weather.SelectToken("id").ToString());

            if (weather.SelectToken("main") is null)
                Main = "";
            else
                Main = weather.SelectToken("main").ToString();

            if (weather.SelectToken("description") is null)
                Description = "";
            else
                Description = weather.SelectToken("description").ToString();

            if (weather.SelectToken("icon") is null)
                Icon = "";
            else
                Icon = weather.SelectToken("icon").ToString();
        }
    }
}
