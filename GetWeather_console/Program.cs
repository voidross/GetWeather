using System;

namespace GetWeather_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "4be5f945e935442b7f785dd39a3c877a";

            GetWeather weather = new GetWeather("Edinburgh", "UK", false, apiKey);             // False = metric, true = imperial readings

            Console.WriteLine(weather.RootModel.Base);
            Console.WriteLine("Temperature: " + weather.RootModel.Main.Temp);
            Console.WriteLine("Description: " + weather.RootModel.Weathers[0].Description.ToUpper());
            Console.WriteLine("Short description : " + weather.RootModel.Weather.Main);

            Console.ReadLine();
        }
    }
}