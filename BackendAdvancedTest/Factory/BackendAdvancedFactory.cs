using BackendAdvancedTest.Model;
using BackendAdvancedTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Factory
{
    /// <summary>
    /// Factory of Backend Advanced Test Models and View Models
    /// </summary>
    public static class BackendAdvancedFactory
    {
        /// <summary>
        /// Creates a City Model
        /// </summary>
        /// <param name="cityVM"></param>
        /// <returns>City</returns> 
        public static City CreateDomainService(CityVM cityVM)
        {
            return new City()
            {
                Name = cityVM.Name
            };
        }

        /// <summary>
        /// Creates a Coordinate Model
        /// </summary>
        /// <param name="coordinateVM"></param>
        /// <returns>Coordinate</returns> 
        public static Coordinate CreateDomainService(CoordinateVM coordinateVM)
        {
            return new Coordinate()
            {
                Latitude = coordinateVM.Latitude,
                Longitude = coordinateVM.Longitude
            };
        }

        /// <summary>
        /// Creates a City View Model
        /// </summary>
        /// <param name="city"></param>
        /// <returns>CityVM</returns> 
        public static CityVM CreateViewModel(City city)
        {
            return new CityVM()
            {
                Name = city.Name
            };
        }

        /// <summary>
        /// Creates a Coordinate View Model
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>CoordinateVM</returns> 
        public static CoordinateVM CreateViewModel(Coordinate coordinate)
        {
            return new CoordinateVM()
            {
                Latitude = coordinate.Latitude,
                Longitude = coordinate.Longitude
            };
        }

        /// <summary>
        /// Creates a playlist View Model
        /// </summary>
        /// <param name="spotifyRecommendationResponse"></param>
        /// <returns>PlaylistVM</returns> 
        public static PlaylistVM CreateViewModel(SpotifyRecommendationResponse spotifyRecommendationResponse)
        {
            PlaylistVM response = new PlaylistVM();
            response.Playlist = spotifyRecommendationResponse.Tracks.Select(t => t.Name).ToList();
            return response;
        }
    }
}
