using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace GetWeather_console
{
    class GetWeather
    {
        private readonly string ApiKey = "4be5f945e935442b7f785dd39a3c877a";

        [JsonProperty("coord")]
        public Coord Coord { get; private set; }

        [JsonProperty("weather")]
        public List<Weather> Weathers { get; private set; } = new List<Weather>();

        [JsonProperty("base")]
        public string Base { get; private set; }

        [JsonProperty("main")]
        public Main Main { get; private set; }

        [JsonProperty("visibility")]
        public long Visibility { get; private set; }

        [JsonProperty("wind")]
        public Wind Wind { get; private set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; private set; }

        [JsonProperty("dt")]
        public double Dt { get; private set; }

        [JsonProperty("sys")]
        public Sys Sys { get; private set; }

        [JsonProperty("timezone")]
        public long Timezone { get; private set; }

        [JsonProperty("id")]
        public double Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("cod")]
        public long Cod { get; private set; }

        public JObject ApiResult { get; private set; }

        public GetWeather(string city, string country, bool unitBool)
        {
            var unit = "metric";

            if (unitBool)
                unit = "imperial";

            var url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "," + country + "&units=" + unit + "&APPID=" + ApiKey;

            string apiResult;
            try
            {
                apiResult = new WebClient().DownloadString(url);
            }
            catch (WebException)
            {
                Console.WriteLine("Unable to connect to Open Weather Map");
                return;
            }

            if (!String.IsNullOrEmpty(apiResult))
            {
                ApiResult = JObject.Parse(apiResult);

                if (ApiResult.SelectToken("coord") is null)
                    return;
                else
                    Coord = new Coord(ApiResult.SelectToken("coord"));

                if (ApiResult.SelectToken("weather") is null)
                    return;
                else
                    foreach (JToken weather in ApiResult.SelectToken("weather"))
                        Weathers.Add(new Weather(weather));

                if (ApiResult.SelectToken("base") is null)
                    return;
                else
                    Base = ApiResult.SelectToken("base").ToString();

                if (ApiResult.SelectToken("main") is null)
                    return;
                else
                    Main = new Main(ApiResult.SelectToken("main"));

                if (ApiResult.SelectToken("visibility") is null)
                    return;
                else
                    Visibility = int.Parse(ApiResult.SelectToken("visibility").ToString());

                if (ApiResult.SelectToken("wind") is null)
                    return;
                else
                    Wind = new Wind(ApiResult.SelectToken("wind"));

                if (ApiResult.SelectToken("clouds") is null)
                    return;
                else
                    Clouds = new Clouds(ApiResult.SelectToken("clouds"));

                if (ApiResult.SelectToken("dt") is null)
                    return;
                else
                    Dt = double.Parse(ApiResult.SelectToken("dt").ToString());

                if (ApiResult.SelectToken("sys") is null)
                    return;
                else
                    Sys = new Sys(ApiResult.SelectToken("sys"));

                if (ApiResult.SelectToken("timezone") is null)
                    return;
                else
                    Timezone = int.Parse(ApiResult.SelectToken("timezone").ToString());

                if (ApiResult.SelectToken("id") is null)
                    return;
                else
                    Id = double.Parse(ApiResult.SelectToken("id").ToString());

                if (ApiResult.SelectToken("name") is null)
                    return;
                else
                    Name = ApiResult.SelectToken("name").ToString();

                if (ApiResult.SelectToken("cod") is null)
                    return;
                else
                    Cod = int.Parse(ApiResult.SelectToken("cod").ToString());
            }
            else
                return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // False = metric, true = imperial readings
            GetWeather weather = new GetWeather("Edinburgh", "UK", false);

            Console.WriteLine("City: " + weather.Name);
            
            Console.WriteLine("Today's weather: " + weather.Weathers[0].Description);
            Console.WriteLine(weather.Weathers[0].Main);

            Console.WriteLine("Temperature: " + weather.Main.Temp);
            Console.WriteLine("Wind speed: " + weather.Wind.Speed);
            //Console.WriteLine("Message: " + weather.Sys.Message);

            Console.ReadLine();
        }
    }
}
