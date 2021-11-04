using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMDb_Lab.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDb_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MovieDAL movieDAL = new MovieDAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieSearch(string Title)
        {
            //get movie
            MovieModel result = movieDAL.GetMovie(Title);

            return View(result);
        }

        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string Title, string Title2, string Title3)
        {
            //get movies
            MovieModel result = movieDAL.GetMovie(Title);
            MovieModel result2 = movieDAL.GetMovie(Title2);
            MovieModel result3 = movieDAL.GetMovie(Title3);
            //add to list
            List<MovieModel> allMovies = new List<MovieModel>{ result, result2, result3};
            return View(allMovies);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
