namespace WeatherBlazor.Utils;
using OpenMeteo;
using System.Globalization;
using Newtonsoft;

public class WeatherHourly
{

    public string[] Time { get; set; }
    public int[] Apparent_temperature { get; set; }

    public WeatherHourly(OpenMeteo.Hourly hourly)
    {


        List<string> list = new();

        foreach (var time in hourly.Time)
        {
        try {
                 DateTime result = DateTime.ParseExact(time, "yyyy-MM-ddTHH:mm" , CultureInfo.InvariantCulture);
                var showTime = result.ToLocalTime().ToShortTimeString();
                   list.Add(showTime);
            }
            catch {
                list.Add(time);
            }
       
        }
        this.Time = list.ToArray();
        this.Apparent_temperature = hourly.Apparent_temperature.Select(t => (int)t).ToArray();

    }
}
