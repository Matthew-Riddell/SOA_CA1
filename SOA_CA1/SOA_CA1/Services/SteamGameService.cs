// Matthew Riddell SOA CA1 - D00245674
// Service for handling Steam Games

using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace SOA_CA1.Services
{
    public class SteamGameService
    {
        private static readonly string GetAppList_URL = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=E624A75E8BF594E01DA1BF4E610ACBE4&steamid=evermatt&format=json"; // steam games
        public List<SteamGame> GetAllSteamGames()
        {
            var client = new RestClient(GetAppList_URL);
            var request = new RestRequest();

            var response = client.Execute(request);
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
