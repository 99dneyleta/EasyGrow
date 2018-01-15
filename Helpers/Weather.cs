using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyGrow.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyGrow.Helpers
{
    public class Weather
    {

        protected static async Task<ICollection<WeatherResponse>> GetWeatherAsync(int? daysCount, [FromBody] Geolocation geolocation, string pathBeforeArgs)
        {
            var client = new HttpClient();
            ICollection<WeatherResponse> allResponses = new List<WeatherResponse>();
            for (int i = 0; i < daysCount; i++)
            {
                string fullPath = pathBeforeArgs + geolocation.Latitude + "," + geolocation.Longitude + "&dt=" + DateTime.Now.AddDays((double)-daysCount + i).ToString("yyyy-MM-dd");
                var response = await client.GetAsync(fullPath);
                var stringResult = await response.Content.ReadAsStringAsync();

                try
                {
                    var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
                    allResponses.Add(rawWeather);
                }
                catch
                {
                    return null;
                }
            }
            return allResponses;
        }


        public static async Task<bool> IsRain(int? daysCount, [FromBody] Geolocation geolocation, string arg = "history")
        {

            try
            {
                string pathBeforeArgs = CreatePathToApi(arg);
                ICollection<WeatherResponse> response = await GetWeatherAsync(daysCount, geolocation, pathBeforeArgs);

                foreach (var day in response)
                {
                    var weatherDayHistory = day.Forecast.ForecastDay.First();
                    foreach (var element in weatherDayHistory.Hour)
                    {
                        if (element.will_it_rain)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string CreatePathToApi(string arg)
        {
            if(arg == "forecast")
            {
                return "http://api.apixu.com/v1/forecast.json?key=fa29b735c66d4cfeb8d131349181001&q=";
            }
            else if(arg == "history")
            {
                return "http://api.apixu.com/v1/history.json?key=fa29b735c66d4cfeb8d131349181001&q=";
            }
            else if(arg == "current")
            {
                return "http://api.apixu.com/v1/current.json?key=fa29b735c66d4cfeb8d131349181001&q=";
            }
            else
            {
                return "Undefined arg in query";
            }
        }
    }

    

    public class WeatherInTime
    {
        public string Time { get; set; }
        public string temp_c { get; set; }
        public bool will_it_rain { get; set; }
    }

    public class AllWeather
    {
        public WeatherInTime DayWeather { get; set; }
    }

    public class ForecastDayElement
    {
        public string Date { get; set; }
        public ICollection<WeatherInTime> Hour { get; set; }
    }

    public class ForecastDay
    {
        public ICollection<ForecastDayElement> Elements { get; set; }
    }

    public class Forecast
    {
        public ICollection<ForecastDayElement> ForecastDay { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }

    public class WeatherResponse
    {
        public Location Location { get; set; }
        public Forecast Forecast { get; set; }
    }

}
