using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Clouds
    {
        public int All { get; private set; }

        public Clouds(JToken clouds)
        {
            All = int.Parse(clouds.SelectToken("all").ToString());
        }
    }
}
