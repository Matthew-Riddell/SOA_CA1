// Matthew Riddell SOA CA1 - D00245674
// Service for handling Steam Games

using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace SOA_CA1.Services
{
    public class SteamGameService
    {
        // older steam app list api used for earlier testing
        // private static readonly string GetAppList_URL = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=STEAMKEY&format=json"; // steam games

        private readonly string _apiKey = "E624A75E8BF594E01DA1BF4E610ACBE4"; 
        private readonly string _steamId = "76561197960434622"; 
        
        // Using the Steam Owned Games api instead
        private static readonly string GetOwnedGames_URL = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/";

        // needed to use async and await for the data to load
        // learned async and await from
        // https://www.geeksforgeeks.org/async-and-await-in-c-sharp/
        public async Task<List<SteamGame>> GetAllSteamGamesAsync()
        {
            //var client = new RestClient(GetAppList_URL);
            //var request = new RestRequest();

            //var response = await client.ExecuteAsync(request);
            //if (response.IsSuccessful && response.Content != null)
            //{
            //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            //    var appListResponse = JsonSerializer.Deserialize<SteamAppListResponse>(response.Content, options);

            //    return appListResponse?.Applist?.Apps ?? new List<SteamGame>();
            //}

            var client = new RestClient(GetOwnedGames_URL);
            var request = new RestRequest();
            request.AddParameter("key", _apiKey);
            request.AddParameter("steamid", _steamId);
            request.AddParameter("include_appinfo", "1"); 
            request.AddParameter("include_played_free_games", "1"); 
            request.AddParameter("format", "json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var appListResponse = JsonSerializer.Deserialize<SteamAppListResponse>(response.Content, options);
                return appListResponse?.Response?.Games ?? new List<SteamGame>();
            }

            return new List<SteamGame>();
        }
    }

    public class SteamAppListResponse
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public List<SteamGame> Games { get; set; }
    }
}
