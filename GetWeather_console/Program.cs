using System;
using System.IO;
using System.Net;
using System.Xml;

namespace GetWeather_console
{
    class Weather
    {
        private string ApiKey = "4be5f945e935442b7f785dd39a3c877a";
        public string Url { get; private set; }
        public string Location { get; private set; }

        public Weather(string location)
        {
            Location = location;
            Url = "https://api.openweathermap.org/data/2.5/weather?q=" + Location + "&mode=xml&units=imperial&APPID=" + ApiKey;
        }

        public string GetWeather()
        {
            WebClient client = new WebClient();
            XmlDocument xmlDocument = new XmlDocument();
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
        
            string xml = client.DownloadString(Url);
            xmlDocument.LoadXml(xml);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlDocument.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Weather weather = new Weather("Edinburgh");
            Console.WriteLine(weather.GetWeather());

            Console.ReadLine();
        }
    }
}
