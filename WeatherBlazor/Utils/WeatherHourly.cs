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
        try {
         var filteredTime = hourly.Time
        .Select(time =>  DateTime.ParseExact(time, "yyyy-MM-ddTHH:mm" , CultureInfo.InvariantCulture))
        .Where(d =>  d.ToLocalTime().Subtract(DateTime.Now).Hours < 5  &&   d.ToLocalTime().Subtract(DateTime.Now).Hours > 0 )
        .Select(d => d.ToLocalTime().ToShortTimeString()).ToArray();
        this.Time = filteredTime;
        }
        catch {
            this.Time = hourly.Time;
        }
       
        this.Apparent_temperature = hourly.Apparent_temperature.Select(t => (int)t).ToArray();

    }
}
