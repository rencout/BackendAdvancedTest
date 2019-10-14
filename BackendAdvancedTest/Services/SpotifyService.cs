using BackendAdvancedTest.Enum;
using BackendAdvancedTest.Model;
using BackendAdvancedTest.Model.Base;
using Liquid;
using Liquid.Base.Domain;
using Liquid.Domain;
using Liquid.Domain.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Services
{
    /// <summary>
    /// Service of Spotify
    /// </summary>
    public class SpotifyService : LightService
    {
        /// <summary>
        /// Service responsible to Request Spotify Token Authorization
        /// </summary> 
        public async Task<string> GetTokenAuthorizationAsync()
        {
            SpotifyAuthorizationResponse spotifyAuthorizationResponse = null;
            try
            {
                string clientIdSpotify = WorkBench.Configuration.GetSection("ClientIdSpotify").Value;
                string clientSecretSpotify = WorkBench.Configuration.GetSection("ClientSecretSpotify").Value;
                string spotifyIdEncode = Encode(clientIdSpotify + ":" + clientSecretSpotify);

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", "Basic " + spotifyIdEncode);
                header.Add("Content-Type", "application/x-www-form-urlencoded");

                string body = "grant_type=client_credentials";

                spotifyAuthorizationResponse = await new ApiWrapper("SpotifyAuthorization").PostAsync<SpotifyAuthorizationResponse>($"", body.ToJsonCamelCase(), header);
            }
            catch (Exception ex)
            {
                AddBusinessInfo("NO_INTERNET");
                Logger.Error(ex, ex.Message);
            }
            return spotifyAuthorizationResponse?.AccessToken;
        }

        /// <summary>
        /// Service responsible to Request Playlist tracks from Spotify
        /// </summary> 
        /// <param name="spotifyToken"></param>
        /// <param name="temperature"></param>
        public async Task<DomainResponse> GetPlaylistAsync(string spotifyToken, double temperature)
        {
            SpotifyRecommendationResponse spotifyRecommendationResponse = null;
            try
            {
                string genre = GetGenreByTemperature(temperature);

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", "Bearer " + spotifyToken);

                spotifyRecommendationResponse = await new ApiWrapper("SpotifyRecommendations").GetAsync<SpotifyRecommendationResponse>($"recommendations?seed_genres={genre}", header);
            }
            catch (Exception ex)
            {
                AddBusinessInfo("NO_INTERNET");
                Logger.Error(ex, ex.Message);
            }
            return Response(spotifyRecommendationResponse);
        }

        /// <summary>
        /// Get Genre to Search by Temperature
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private string GetGenreByTemperature(double temperature)
        {
            if (temperature > 30)
            {
                return GenresType.party.ToString();
            }
            else if (15 <= temperature && temperature <= 30)
            {
                return GenresType.pop.ToString();
            }
            else if (10 <= temperature && temperature < 15)
            {
                return GenresType.rock.ToString();
            }
            else
            {
                return GenresType.classical.ToString();
            }
        }

        /// <summary>
        /// Encode Base64
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Encode(string data)
        {
            Byte[] b = UTF8Encoding.UTF8.GetBytes(data);
            string criptografaConnectionString = Convert.ToBase64String(b);
            return criptografaConnectionString;
        }
    }
}
