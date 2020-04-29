using Newtonsoft.Json.Linq;

namespace GetWeather_console
{
    public class Sys
    {
        public int Type { get; private set; }
        public int Id { get; private set; }
        //public float Message { get; private set; }
        public string Country { get; private set; }
        public double Sunrise { get; private set; }
        public double Sunset { get; private set; }

        public Sys(JToken sys)
        {
            Type = int.Parse(sys.SelectToken("type").ToString());
            Id = int.Parse(sys.SelectToken("id").ToString());
            //Message = float.Parse(sys.SelectToken("message").ToString());
            Country = sys.SelectToken("country").ToString();
            Sunrise = double.Parse(sys.SelectToken("sunrise").ToString());
            Sunset = double.Parse(sys.SelectToken("sunset").ToString());
        }
    }
}
