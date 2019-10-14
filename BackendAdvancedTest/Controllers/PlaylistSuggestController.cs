using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAdvancedTest.Factory;
using BackendAdvancedTest.Model;
using BackendAdvancedTest.Services;
using BackendAdvancedTest.ViewModel;
using Liquid.Activation;
using Liquid.Base.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackendAdvancedTest.Controllers
{
    /// <summary>
    /// Controller responsible for manage Playlist Suggest
    /// </summary>
    [ApiVersion("1")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class PlaylistSuggestController : LightController
    {
        /// <summary>
        /// Api responsible to return Playlist Suggest by City Name
        /// </summary>
        /// <param name="cityVM"></param>   
        /// <returns></returns>
        [HttpPost("playlistByCityName")]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task<IActionResult> PlaylistByCityName([FromBody] CityVM cityVM)
        {
            ValidateInput(cityVM);
            City city = BackendAdvancedFactory.CreateDomainService(cityVM);
            var temperature = await Factory<OpenWeatherService>().GetWeatherByCityAsync(city);

            var spotifyService = Factory<SpotifyService>();
            var spotifyToken = await spotifyService.GetTokenAuthorizationAsync();
            var response = await spotifyService.GetPlaylistAsync(spotifyToken, temperature.Value);

            response.ViewModelData = BackendAdvancedFactory.CreateViewModel(response.ModelData as SpotifyRecommendationResponse);
            return Result(response);
        }

        /// <summary>
        /// Api responsible to return Playlist Suggest by Coordinate
        /// </summary>
        /// <param name="coordinateVM"></param> 
        /// <returns></returns>
        [HttpPost("playlistByCoordinate")]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task<IActionResult> PlaylistByCoordinate([FromBody] CoordinateVM coordinateVM)
        {
            ValidateInput(coordinateVM);
            Coordinate coordinate = BackendAdvancedFactory.CreateDomainService(coordinateVM);
            var temperature = await Factory<OpenWeatherService>().GetWeatherByCoordinateAsync(coordinate);

            var spotifyService = Factory<SpotifyService>();
            var spotifyToken = await spotifyService.GetTokenAuthorizationAsync();
            var response = await spotifyService.GetPlaylistAsync(spotifyToken, temperature.Value);

            response.ViewModelData = BackendAdvancedFactory.CreateViewModel(response.ModelData as SpotifyRecommendationResponse);
            return Result(response);
        }
    }
}
