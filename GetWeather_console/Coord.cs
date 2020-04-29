using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Coord
    {
        public double Lon { get; private set; }
        public double Lat { get; private set; }

        public Coord(JToken coords)
        {
            Lon = double.Parse(coords.SelectToken("lon").ToString());
            Lat = double.Parse(coords.SelectToken("lat").ToString());
        }
    }
}
