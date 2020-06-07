using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.Models
{
    public class Movie
    {
       
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int SeatsLeft { get; set; }
        public string Showtime { get; set; }

        [Display(Name = "Production_Year")]
        public string Productionyear { get; set; }
        public ICollection<Order> Orders { get; set; }



    }
}

