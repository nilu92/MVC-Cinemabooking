using Lab1ASP.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.Services
{
   public interface IMovie
    {
        ICollection<Movie> GetAllMovies();
    }
}
