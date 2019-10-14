using BackendAdvancedTest.Model.Base;
using Liquid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model
{
    /// <summary>
    /// Model from SpotifyRecommendationResponse
    /// </summary>
    public class SpotifyRecommendationResponse : LightModel<SpotifyRecommendationResponse>
    {
        /// <summary>
        /// List of tracks
        /// </summary>
        public List<Track> Tracks { get; set; }

        /// <summary>
        /// Validate SpotifyRecommendationResponse's fields
        /// </summary>
        public override void Validate()
        {
        }
    }
}
