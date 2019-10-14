using Liquid.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model
{
    /// <summary>
    /// Model from SpotifyAuthorizationResponse
    /// </summary>
    public class SpotifyAuthorizationResponse : LightModel<SpotifyAuthorizationResponse>
    {
        /// <summary>
        /// Spotify Access Token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Validate SpotifyAuthorizationResponse's fields
        /// </summary>
        public override void Validate()
        {
            
        }
    }
}
