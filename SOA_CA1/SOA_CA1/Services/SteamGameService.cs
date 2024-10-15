// Matthew Riddell SOA CA1 - D00245674
// Service for handling Steam Games
// this is a test class for testing the output from the API as I develop the actual service

using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace SOA_CA1.Services
{
    public class SteamGameService
    {
        private static readonly string GetAppList_URL = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=STEAMKEY&format=json"; // steam games

        // needed to use async and await for the data to load
        // learned async and await from
        // https://www.geeksforgeeks.org/async-and-await-in-c-sharp/
        public async Task<List<SteamGame>> GetAllSteamGamesAsync()
        {
            var client = new RestClient(GetAppList_URL);
            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var appListResponse = JsonSerializer.Deserialize<SteamAppListResponse>(response.Content, options);

                return appListResponse?.Applist?.Apps ?? new List<SteamGame>();
            }

            return new List<SteamGame>();
        }
    }

    public class SteamAppListResponse
    {
        public SteamAppList Applist { get; set; }
    }

    public class SteamAppList
    {
        public List<SteamGame> Apps { get; set; }
    }
}
