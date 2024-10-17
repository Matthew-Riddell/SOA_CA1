// Matthew Riddell SOA CA1 - D00245674
// API Service abstract class

using RestSharp;
using System.Text.Json;

namespace SOA_CA1.Services
{
    public abstract class ApiService<T>
    {
        protected abstract string ApiUrl { get; }
        protected abstract string ApiKey { get; }


        // Grab data from the APIs and deserialize
        protected async Task<T> FetchDataAsync(RestRequest request)
        {
            var client = new RestClient(ApiUrl);
            request.AddParameter("apikey", ApiKey); // Add API key to request

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<T>(response.Content, options);
            }

            return default;
        }
    }
}
