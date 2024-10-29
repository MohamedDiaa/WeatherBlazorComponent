namespace WeatherBlazor.Utils;
using OpenMeteo;
using Newtonsoft;
using Newtonsoft.Json;
using System.Globalization;

public class WeatherDaily
{
    public string[] Time { get; set; }
    public int[] Apparent_temperature_max { get; set; }
    public int[] Apparent_temperature_min { get; set; }

    public WeatherDaily(OpenMeteo.Daily daily)
    {

        List<string> list = new();

        foreach (var time in daily.Time)
        {
            try
            {
                DateTime result = DateTime.ParseExact(time, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var dayName = result.DayOfWeek.ToString().Substring(0, 3);
                list.Add(dayName);

            }
            catch
            {
                list.Add(time);
            }
        }
        this.Time = list.ToArray();

          this.Apparent_temperature_max = daily.Apparent_temperature_max.Select(t =>  (int)t).ToArray();

        this.Apparent_temperature_min = daily.Apparent_temperature_min.Select(t => (int)t).ToArray();

    }
}
