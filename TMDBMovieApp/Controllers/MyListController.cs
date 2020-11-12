using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TMDBMovieApp.Models;

namespace TMDBMovieApp.Controllers
{
    public class MyListController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string _apiPath;
        private readonly string _apiKey;
        private readonly string _additionalPath = "/search/movie";
        private readonly IWebHostEnvironment _env;

        public MyListController(IOptions<AppSettings> appSettings, IWebHostEnvironment env)
        {
            _appSettings = appSettings;
            _apiPath = _appSettings.Value.APIPath;
            _apiKey = _appSettings.Value.APIKey;
            _env = env;
        }

        public string BuildQuery(string apiPath, string apiKey, string additionalPath, params string[] additionalParameters)
        {
            string query = apiPath + additionalPath + "?api_key=" + apiKey;
            foreach (var param in additionalParameters)
            {
                query += "&" + param;
            }

            return query;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<Movie>> GetMovies(string value, int numberOfItems)
        {
            
            MovieList movieList;
            value = "query=" + value;
            string query = BuildQuery(_apiPath, _apiKey, _additionalPath, new string[2]{"language=pl-pl", value});
            System.Diagnostics.Debug.WriteLine("QUERY: " + query);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(query))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<MovieList>(apiResponse);
                }
            }
            List<Movie> listToReturn = new List<Movie>();
            for (int i = 0; i < numberOfItems && i<movieList.results.Count; i++)
            {
                
                if(movieList.results[i].poster_path is null)
                    movieList.results[i].poster_path = "/images/placeholder.jpg";
                else
                    movieList.results[i].poster_path = "https://image.tmdb.org/t/p/w185/" + movieList.results[i].poster_path;
                listToReturn.Add(movieList.results[i]);
            }
            return listToReturn;
        }
    }
}
