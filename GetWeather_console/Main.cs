using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Main
    {
        public float Temp { get; private set; }
        public float FeelsLike { get; private set; }
        public float Pressure { get; private set; }
        public float Humidity { get; private set; }
        public float TempMin { get; private set; }
        public float TempMax { get; private set; }

        public Main(JToken main)
        {
            Temp = float.Parse(main.SelectToken("temp").ToString());
            FeelsLike = float.Parse(main.SelectToken("feels_like").ToString());
            Pressure = float.Parse(main.SelectToken("pressure").ToString());
            Humidity = float.Parse(main.SelectToken("humidity").ToString());
            TempMin = float.Parse(main.SelectToken("temp_min").ToString());
            TempMax = float.Parse(main.SelectToken("temp_max").ToString());

        }
    }
}
