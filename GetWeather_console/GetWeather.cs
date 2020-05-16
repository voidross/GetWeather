using Newtonsoft.Json;
using System;
using System.Net;

namespace GetWeather_console
{
    class GetWeather
    {
        public RootModel RootModel { get; set; }

        public GetWeather(string city, string country, bool unitBool, string apiKey)
        {
            var unit = "metric";

            if (unitBool)
                unit = "imperial";

            var url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "," + country + "&units=" + unit + "&APPID=" + apiKey;

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

            RootModel = JsonConvert.DeserializeObject<RootModel>(apiResult);
        }
    }
}