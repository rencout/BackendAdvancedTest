using Liquid.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model.Base
{
    /// <summary>
    /// Model defines of track
    /// </summary>
    public class Track : LightModel<Track>
    {
        /// <summary>
        /// Name of track
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Validate Track's fields
        /// </summary>
        public override void Validate()
        {
        }
    }
}
