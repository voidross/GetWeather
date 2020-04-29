using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Wind
    {
        public float Speed { get; private set; }
        public int Deg { get; private set; }

        public Wind(JToken wind)
        {
            Speed = float.Parse(wind.SelectToken("speed").ToString());
            Deg = int.Parse(wind.SelectToken("deg").ToString());
        }
    }
}
