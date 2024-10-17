// Matthew Riddell SOA CA1 - D00245674
// Service for handling Steam Games

using RestSharp;
using System.Text.Json;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace SOA_CA1.Services
{
    public class SteamGameService // : ApiService<SteamAppListResponse>
    {
        // older steam app list api used for earlier testing
        // private static readonly string GetAppList_URL = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=STEAMKEY&format=json"; // steam games
        
        // Steam Owned Games API 
        private static readonly string GetOwnedGames_URL = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/";
        // Steam Number of Current Players API
        private static readonly string GetNumberOfCurrentPlayers_URL = "https://api.steampowered.com/ISteamUserStats/GetNumberOfCurrentPlayers/v1/";

        private readonly string _apiKey = "E624A75E8BF594E01DA1BF4E610ACBE4";
        private readonly string _steamId = "76561197960434622";

        // needed to use async and await for the data to load
        // learned async and await and using tasks from
        // https://www.geeksforgeeks.org/async-and-await-in-c-sharp/

        // Display Steam games
        public async Task<List<SteamGame>> GetAllSteamGamesAsync()
        {
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
                // Console.WriteLine(response.Content); // test JSON output

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var appListResponse = JsonSerializer.Deserialize<SteamAppListResponse>(response.Content, options);
                return appListResponse?.Response?.Games ?? new List<SteamGame>();
            }
            return new List<SteamGame>();
        }

        // Display player count of each game
        //public async Task<int> GetCurrentPlayerCountAsync(int appId)
        //{
        //    var client = new RestClient(GetNumberOfCurrentPlayers_URL);
        //    var request = new RestRequest();
        //    request.AddParameter("appid", appId);  

        //    var response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessful && response.Content != null)
        //    {
        //        // Console.WriteLine(response.Content); // test JSON output

        //        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //        var playerCountResponse = JsonSerializer.Deserialize<PlayerCountResponse>(response.Content, options);
        //        return playerCountResponse?.Response?.PlayerCount ?? 0;
        //    }
        //    return 0;  
        //}
    }

    // Classes for deserializing the JSON data
    // Steam Games Data
    public class SteamAppListResponse
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public List<SteamGame> Games { get; set; }
    }

    // Steam Player Counts
    //public class PlayerCountResponse
    //{
    //    public PlayerCountResponseData Response { get; set; }
    //}

    //public class PlayerCountResponseData
    //{
    //    public int PlayerCount { get; set; } 
    //}

}
