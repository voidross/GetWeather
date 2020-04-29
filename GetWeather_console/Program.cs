using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace GetWeather_console
{
    class GetWeather
    {
        private readonly string ApiKey = "4be5f945e935442b7f785dd39a3c877a";
        public Coord Coord { get; private set; }
        public List<Weather> Weathers { get; private set; } = new List<Weather>();
        public string Base { get; private set; }
        public Main Main { get; private set; }
        public int Visibility { get; private set; }
        public Wind Wind { get; private set; }
        public Clouds Clouds { get; private set; }
        public double Dt { get; private set; }
        public Sys Sys { get; private set; }
        public int Timezone { get; private set; }
        public double Id { get; private set; }
        public string Name { get; private set; }
        public int Cod { get; private set; }

        public JObject ApiResult { get; private set; }

        public GetWeather(string city, string country, bool unitBool)
        {
            var unit = "metric";

            if (unitBool)
                unit = "imperial";

            var url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "," + country + "&units=" + unit + "&APPID=" + ApiKey;

            ApiResult = JObject.Parse(new WebClient().DownloadString(url));

            Coord = new Coord(ApiResult.SelectToken("coord"));
            foreach (JToken weather in ApiResult.SelectToken("weather"))
                Weathers.Add(new Weather(weather));
            Base = ApiResult.SelectToken("base").ToString();
            Main = new Main(ApiResult.SelectToken("main"));
            Visibility = int.Parse(ApiResult.SelectToken("visibility").ToString());
            Wind = new Wind(ApiResult.SelectToken("wind"));
            Clouds = new Clouds(ApiResult.SelectToken("clouds"));
            Dt = double.Parse(ApiResult.SelectToken("dt").ToString());
            Sys = new Sys(ApiResult.SelectToken("sys"));
            Timezone = int.Parse(ApiResult.SelectToken("timezone").ToString());
            Id = double.Parse(ApiResult.SelectToken("id").ToString());
            Name = ApiResult.SelectToken("name").ToString();
            Cod = int.Parse(ApiResult.SelectToken("cod").ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // False = metric, true = imperial readings
            GetWeather weather = new GetWeather("Edinburgh", "UK", false);

            Console.WriteLine("City: " + weather.Name);
            Console.WriteLine("Temperature: " + weather.Main.Temp);
            Console.WriteLine("Wind speed: " + weather.Wind.Speed);

            Console.ReadLine();
        }
    }
}
