using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Weather
    {
        public int Id { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public Weather(JToken weather)
        {
            Id = int.Parse(weather.SelectToken("id").ToString());
            Main = weather.SelectToken("main").ToString();
            Description = weather.SelectToken("description").ToString();
            Icon = weather.SelectToken("icon").ToString();
        }
    }
}
