// Matthew Riddell SOA CA1 - D00245674
// Service for handling OMDb Movies

using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SOA_CA1.Services
{
    public class OmdbMovieService : ApiService<Movie>
    {
        
        // OMDb Films API
        protected override string ApiUrl => "https://www.omdbapi.com/";
        protected override string ApiKey => "6d918ec8"; 


        // Display movies by title
        //public async Task<Movie> GetMovieByTitleAsync(string title)
        //{
        //    var client = new RestClient(OMDb_URL);
        //    var request = new RestRequest();
        //    request.AddParameter("t", title); 
        //    request.AddParameter("apikey", _apiKey); 

        //    var response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessful && response.Content != null)
        //    {
        //        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //        var movie = JsonSerializer.Deserialize<Movie>(response.Content, options);
        //        return movie;
        //    }

        //    return null; 
        //}

        // Display Movies by title
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            var request = new RestRequest();
            request.AddParameter("t", title); // Movie title

            return await FetchDataAsync(request);
        }

        // Display Movies by IMDB ID
        // for testing IDs
        //public async Task<Movie> GetMovieByIdAsync(string imdbId)
        //{
        //    var client = new RestClient(OMDb_URL);
        //    var request = new RestRequest();
        //    request.AddParameter("i", imdbId); 
        //    request.AddParameter("apikey", _apiKey); 

        //    var response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessful && response.Content != null)
        //    {
        //        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //        var movie = JsonSerializer.Deserialize<Movie>(response.Content, options);
        //        return movie;
        //    }

        //    return null; 
        //}

    }
}
