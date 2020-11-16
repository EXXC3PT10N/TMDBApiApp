using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TMDBMovieApp.Models;

namespace TMDBMovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string _apiPath;
        private readonly string _apiKey;
        private readonly string _additionalPath;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
            _apiPath = _appSettings.Value.APIPath;
            _apiKey = _appSettings.Value.APIKey;
            _additionalPath = _appSettings.Value.APIEndpoints.Trending;
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
            Trending trending;
            string query = BuildQuery(_apiPath, _apiKey, _additionalPath, "language=pl-pl");
            System.Diagnostics.Debug.WriteLine("QUERY: " + query);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(query))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trending = JsonConvert.DeserializeObject<Trending>(apiResponse);
                }
            }
            return View(trending.results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
