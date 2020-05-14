using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; private set; }

        [JsonProperty("lat")]
        public double Lat { get; private set; }

        public Coord(JToken coords)
        {
            if (coords.SelectToken("lon") is null)
                Lon = -1;
            else
                Lon = double.Parse(coords.SelectToken("lon").ToString());

            if (coords.SelectToken("lat") is null)
                Lat = -1;
            else
                Lat = double.Parse(coords.SelectToken("lat").ToString());
        }
    }
}
