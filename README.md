# SOA_CA1
CA1 for Service Orientated Architecture 

**Matt's Entertainment Center**

## Features

- **Movie Search**: Search for movies by title and view details such as genre, director, actors, and plot.
- **Upload Movie Data**: Upload movie data in JSON format and display the uploaded movie information.
- **Steam Games List**: Browse through a list of Steam games, complete with icons and playtime details.

## Technologies Used

- **Frontend**: Blazor, HTML, CSS
- **Backend**: C# (.NET)
- **APIs**: OMDb API for movie data, Steam API for game data
- **Data Serialization**: System.Text.Json

## Backend classes

- **Abstract Services Class (ApiService.cs)**
- **Steam Api Services Class (SteamGameService.cs)**
- **OMDb Api Services Class (OmbdMovieService.cs)**
- **Steam Game Object Class (SteamGame.cs)**
- **OMDb Movie Object Class (Movie.cs)**

## Frontend Pages

- **Steam Games List (SteamGames.razor)**
- **OMDb Movie Search (MovieSearch.razor)**
- **Upload Movie Data (MovieUpload.razor)**

## Resources used 

- **Steam Api Documentation**:
- https://steamcommunity.com/dev

- **OMDb Api Documentation**:
- https://www.omdbapi.com/

- **Resources used for programming stuff**:
- https://www.geeksforgeeks.org/async-and-await-in-c-sharp/
- https://blazor-university.com/dependency-injection/injecting-dependencies-into-blazor-components/
- https://medium.com/@Has_San/json-handling-in-c-a-comprehensive-guide-for-developers-0ed233365bf2
- https://briancaos.wordpress.com/2023/04/28/c-use-httpclient-to-get-json-from-api-endpoint/
- https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability

- **Visual Studio Gitignore**:
- https://github.com/github/gitignore/blob/main/VisualStudio.gitignore


