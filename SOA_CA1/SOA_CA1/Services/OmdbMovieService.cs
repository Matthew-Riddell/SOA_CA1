using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SOA_CA1.Services
{
    public class OmdbMovieService
    {
        private readonly string _apiKey = "6d918ec8";
        
        // OMDb Films API
        private static readonly string OMDb_URL = "https://www.omdbapi.com/";

        // Display movies by title
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            var client = new RestClient(OMDb_URL);
            var request = new RestRequest();
            request.AddParameter("t", title); 
            request.AddParameter("apikey", _apiKey); 

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var movie = JsonSerializer.Deserialize<Movie>(response.Content, options);
                return movie;
            }

            return null; 
        }

        // Display Movies by IMDB ID
        // for testing IDs
        public async Task<Movie> GetMovieByIdAsync(string imdbId)
        {
            var client = new RestClient(OMDb_URL);
            var request = new RestRequest();
            request.AddParameter("i", imdbId); 
            request.AddParameter("apikey", _apiKey); 

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var movie = JsonSerializer.Deserialize<Movie>(response.Content, options);
                return movie;
            }

            return null; 
        }

    }
}
