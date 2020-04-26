using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace GetWeather_console
{
    class GetWeather
    {
        private string ApiKey = "4be5f945e935442b7f785dd39a3c877a";
        public string Location { get; private set; }
        public string Unit { get; private set; }
        public string Url { get; private set; }
        public dynamic Weather { get; private set; }
        public JToken WeatherMain { get; private set; }

        public GetWeather(string location, bool unit)
        {
            Location = location;

            if (unit == true)
                Unit = "imperial";
            else
                Unit = "metric";

            Url = "https://api.openweathermap.org/data/2.5/weather?q=" + Location + "&units=" + Unit + "&APPID=" + ApiKey;

            var json = new WebClient().DownloadString(Url);

            Weather = JObject.Parse(json);

            //The "weather" section of the returned JSON is an array. Using JToken to access.
            WeatherMain = Weather["weather"].First["main"];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GetWeather weather = new GetWeather("Edinburgh", false);

            Console.WriteLine("Location: " + weather.Weather.name);
            Console.WriteLine("Weather: " + weather.WeatherMain);
            Console.WriteLine("Temperature: " + weather.Weather.main.temp);
            Console.WriteLine("Min: " + weather.Weather.main.temp_min);
            Console.WriteLine("Max: " + weather.Weather.main.temp_max);
            Console.WriteLine("Wind speed: " + weather.Weather.wind.speed);

            Console.ReadLine();
        }
    }
}
