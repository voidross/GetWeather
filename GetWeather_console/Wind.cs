using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Wind
    {
        [JsonProperty("speed")]
        public float Speed { get; private set; }

        [JsonProperty("deg")]
        public int Deg { get; private set; }

        public Wind(JToken wind)
        {
            if (wind.SelectToken("speed") is null)
                Speed = -1;
            else
                Speed = float.Parse(wind.SelectToken("speed").ToString());

            if (wind.SelectToken("deg") is null)
                Deg = -1;
            else
                Deg = int.Parse(wind.SelectToken("deg").ToString());
        }
    }
}
