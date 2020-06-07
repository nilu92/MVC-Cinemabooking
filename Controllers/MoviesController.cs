using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1ASP.NetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab1ASP.NetCore.Controllers
{
    public class MoviesController : Controller
    {
        public IMovie Movie { get; set; }
        public MoviesController(IMovie _Movie)
        {
            Movie = _Movie;
        }
        public IActionResult Index()
        {
            var movies = Movie.GetAllMovies();
            return View(movies);
        }
    }
}