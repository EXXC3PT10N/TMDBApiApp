using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TMDBMovieApp.Data;
using TMDBMovieApp.Models;

namespace TMDBMovieApp.Controllers
{
    public class MyListController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string _apiPath;
        private readonly string _apiKey;
        private readonly string _searchMoviePath;
        private readonly string _hMovieDetailsPath;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        //private readonly UserManager<AspNetUsers> _userManager;

        public MyListController(IOptions<AppSettings> appSettings, IWebHostEnvironment env, ApplicationDbContext context)
        {
            _appSettings = appSettings;
            _apiPath = _appSettings.Value.APIPath;
            _apiKey = _appSettings.Value.APIKey;
            _searchMoviePath = _appSettings.Value.APIEndpoints.SearchMovie;
            _hMovieDetailsPath = _appSettings.Value.APIEndpoints.MovieDetails;
            _env = env;
            _context = context;
            //_userManager = userManager;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                System.Diagnostics.Debug.WriteLine("USER ID: " + userId);

                var listIds = await _context.Lists.Where(x => x.OwnerId.Equals(userId)).Select(x => x.Id).ToListAsync();
                var moviesIds = await _context.MoviesInLists.Where(x => x.IdListNavigationId == listIds.First()).Select(x => x.IdMovie).ToListAsync();

                List<Movie> movies = new List<Movie>();
                foreach (var movieID in moviesIds)
                {

                    string query = BuildQuery(_apiPath, _apiKey, _hMovieDetailsPath + movieID, new string[1] { "language=pl-pl" });
                    System.Diagnostics.Debug.WriteLine("Movie ID: " + movieID);
                    System.Diagnostics.Debug.WriteLine("Movie QUERY: " + query);
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync(query))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            movies.Add(JsonConvert.DeserializeObject<Movie>(apiResponse));
                        }
                    }
                }
                //var item = await _context.MoviesInLists.Select(x => x.Id).ToListAsync();
                //System.Diagnostics.Debug.WriteLine("ITEM: "+item.First());
                return View(movies);
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return View();
            }
            

        }

        [HttpPost]
        public async Task<List<Movie>> GetMovies(string value, int numberOfItems)
        {
            MovieList movieList;
            value = "query=" + value;
            string query = BuildQuery(_apiPath, _apiKey, _searchMoviePath, new string[2]{"language=pl-pl", value});
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

        [HttpGet]
        public async Task<IActionResult> AddMovie(int id)
        {
            System.Diagnostics.Debug.WriteLine("ID: " + id);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listIds = await _context.Lists.Where(x => x.OwnerId.Equals(userId)).Select(x => x.Id).ToListAsync();

            MoviesInLists movie = new MoviesInLists();
            movie.IdMovie = id;
            movie.IdListNavigationId = listIds.First();
            _context.MoviesInLists.Add(movie);
            _context.SaveChanges();
            return Redirect("~/MyList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            System.Diagnostics.Debug.WriteLine("ID: " + id);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listIds = await _context.Lists.Where(x => x.OwnerId.Equals(userId)).Select(x => x.Id).ToListAsync();

            MoviesInLists movie = new MoviesInLists();
            movie.IdMovie = id;
            movie.IdListNavigationId = listIds.First();
            // var entity = _context.MoviesInLists.Attach(movie);
            var movieId = await _context.MoviesInLists.Where(c => c.IdMovie == id && c.IdListNavigationId == listIds.First()).Select(c => c.Id).ToListAsync();
            //var finded = _context.MoviesInLists.Find(movie);
            movie.Id = movieId.First();
            System.Diagnostics.Debug.WriteLine("Finded ID: " + movie.Id);
            _context.MoviesInLists.Remove(movie);
            //entity.State = EntityState.Deleted;
            
            await _context.SaveChangesAsync();
            return Redirect("~/MyList");
        }
    }
}
