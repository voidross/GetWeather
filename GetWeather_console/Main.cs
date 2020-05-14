using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Main
    {
        [JsonProperty("temp")]
        public float Temp { get; private set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; private set; }

        [JsonProperty("temp_min")]
        public float TempMin { get; private set; }

        [JsonProperty("temp_max")]
        public float TempMax { get; private set; }

        [JsonProperty("pressure")]
        public float Pressure { get; private set; }

        [JsonProperty("humidity")]
        public float Humidity { get; private set; }

        public Main(JToken main)
        {
            if (main.SelectToken("temp") is null)
                Temp = -1;
            else
                Temp = float.Parse(main.SelectToken("temp").ToString());

            if (main.SelectToken("feels_like") is null)
                FeelsLike = -1;
            else
                FeelsLike = float.Parse(main.SelectToken("feels_like").ToString());

            if (main.SelectToken("pressure") is null)
                Pressure = -1;
            else
                Pressure = float.Parse(main.SelectToken("pressure").ToString());

            if (main.SelectToken("humidity") is null)
                Humidity = -1;
            else
                Humidity = float.Parse(main.SelectToken("humidity").ToString());

            if (main.SelectToken("temp_min") is null)
                TempMin = -1;
            else
                TempMin = float.Parse(main.SelectToken("temp_min").ToString());

            if (main.SelectToken("temp_max") is null)
                TempMax = -1;
            else
                TempMax = float.Parse(main.SelectToken("temp_max").ToString());
        }
    }
}
