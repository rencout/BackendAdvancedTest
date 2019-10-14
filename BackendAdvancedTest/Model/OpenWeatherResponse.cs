using BackendAdvancedTest.Model.Base;
using Liquid.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model
{
    /// <summary>
    /// Model from OpenWeatherResponse
    /// </summary>
    public class OpenWeatherResponse : LightModel<OpenWeatherResponse>
    {
        /// <summary>
        /// Main object
        /// </summary>
        [JsonProperty("main")]
        public Main Main { get; set; }

        /// <summary>
        /// Validates OpenWeatherResponse's fields
        /// </summary>
        public override void Validate()
        {
        }
    }
}
