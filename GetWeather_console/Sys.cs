using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace GetWeather_console
{
    public class Sys
    {
        [JsonProperty("type")]
        public long Type { get; private set; }

        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("country")]
        public string Country { get; private set; }

        [JsonProperty("message")]
        public float Message { get; private set; }

        [JsonProperty("sunrise")]
        public double Sunrise { get; private set; }

        [JsonProperty("sunset")]
        public double Sunset { get; private set; }
        public Sys(JToken sys)
        {
            if (sys.SelectToken("type").Type == JTokenType.Null)
                Type = -1;
            else
                Type = int.Parse(sys.SelectToken("type").ToString());

            if (sys.SelectToken("id") is null)
                Id = -1;
            else
                Id = int.Parse(sys.SelectToken("id").ToString());

            if (sys.SelectToken("message") is null)
                Message = -1;
            else
                Message = float.Parse(sys.SelectToken("message").ToString());

            if (sys.SelectToken("country") is null)
                Country = "";
            else 
                Country = sys.SelectToken("country").ToString();

            if (sys.SelectToken("sunrise") is null)
                Sunrise = -1;
            else 
                Sunrise = double.Parse(sys.SelectToken("sunrise").ToString());

            if (sys.SelectToken("sunset") is null)
                Sunset = -1;
            else
                Sunset = double.Parse(sys.SelectToken("sunset").ToString());
        }
    }
}
