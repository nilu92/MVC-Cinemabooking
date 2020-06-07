using Lab1ASP.NetCore.BerrasData;
using Lab1ASP.NetCore.Models;
using Lab1ASP.NetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.Repository
{
    public class MovieRepository : IMovie
    {
        public BerrasDBContext DB;
        public MovieRepository(BerrasDBContext _DB)
        {

            DB = _DB;
        }
        public ICollection<Movie> GetAllMovies()
        {
            return DB.Movies.ToList();
        }
    }
}
