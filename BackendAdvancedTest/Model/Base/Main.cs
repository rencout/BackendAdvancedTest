using Liquid.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model.Base
{
    /// <summary>
    /// Model Main
    /// </summary>
    public class Main : LightModel<Main>
    {
        /// <summary>
        /// Tempeture of City
        /// </summary>
        [JsonProperty("temp")]
        public double Temp { get; set; }

        /// <summary>
        /// Validate Main's fields
        /// </summary>
        public override void Validate()
        {
        }
    }
}
