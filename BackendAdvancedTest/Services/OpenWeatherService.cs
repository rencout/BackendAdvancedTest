using BackendAdvancedTest.Model;
using Liquid;
using Liquid.Base.Domain;
using Liquid.Domain;
using Liquid.Domain.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Services
{
    /// <summary>
    /// Service of Open Weather
    /// </summary>
    public class OpenWeatherService : LightService
    {
        private readonly string apiKey = WorkBench.Configuration.GetSection("ApiKeyOpenWeather").Value;

        /// <summary>
        /// Service responsible to Get Weather by City
        /// </summary>
        /// <param name="city">Model City</param>
        /// <returns>Temp</returns>  
        public async Task<double?> GetWeatherByCityAsync(City city)
        {
            OpenWeatherResponse openWeatherResponse = null;
            try
            {
                openWeatherResponse = await new ApiWrapper("OpenWeather").GetAsync<OpenWeatherResponse>($"/weather?q={city.Name}&units=metric&APPID={apiKey}");
            }
            catch (Exception ex)
            {
                AddBusinessInfo("NO_INTERNET");
                Logger.Error(ex, ex.Message);
            }
            return openWeatherResponse?.Main.Temp;
        }

        /// <summary>
        /// Service responsible to Get Weather by Coordinate
        /// </summary>
        /// <param name="coordinate">Model City</param>
        /// <returns>Temp</returns>  
        public async Task<double?> GetWeatherByCoordinateAsync(Coordinate coordinate)
        {
            OpenWeatherResponse openWeatherResponse = null;
            try
            {
                openWeatherResponse = await new ApiWrapper("OpenWeather").GetAsync<OpenWeatherResponse>($"/weather?lat={coordinate.Latitude}&lon={coordinate.Longitude}&units=metric&APPID={apiKey}");
            }
            catch (Exception ex)
            {
                AddBusinessInfo("NO_INTERNET");
                Logger.Error(ex, ex.Message);
            }
            return openWeatherResponse?.Main.Temp;
        }
    }
}
