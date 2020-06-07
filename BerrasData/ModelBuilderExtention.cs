using Lab1ASP.NetCore.BerrasData;
using Lab1ASP.NetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.BioDbContext
{
    public static class ModelBuilderExtention
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Movie>().HasData(

                new Movie()
                {
                    ID = 1,
                    Title = "Black Panther",
                    Genre = "Action",
                    Productionyear = "2017",
                    Showtime = "Juni 14-2020 17:30 PM",
                    SeatsLeft = 50
                },
              new Movie()
              {
                  ID = 2,
                  Title = "Wonder Woman",
                  Genre = "Action",
                  Productionyear = "2017",
                  Showtime = "Juni 14-2020 15:00 PM",
                  SeatsLeft = 50

              },
             new Movie()
             {
                 ID = 3,
                 Title = "Avengers:Endgame ",
                 Genre = "Action",
                 Productionyear = "2019",
                 Showtime = "Juni 16-2020 17:00 PM",
                 SeatsLeft = 50
             },
              new Movie()
              {
                  ID = 4,
                  Title = "The Irishman",
                  Genre = "Drama",
                  Productionyear = "2019",
                  Showtime = "Juni 16-2020 20:00 PM",
                  SeatsLeft = 50
              },
              new Movie()
              {
                  ID = 5,
                  Title = "Lady Bird",
                  Genre = "Drama",
                  Productionyear = "2018",
                  Showtime = "Juni 17-2020 15:00 PM",
                  SeatsLeft = 50
              }

             );




            //new ViewingGallery()
            //{
            //    ViewingID = 3,

            //    Movie = new Movie()
            //    {
            //        ID = 3,
            //        Title = "Wonder Woman",
            //        Type = "Action",
            //        Productionyear = "2017"
            //    },
            //    ShowTime = "Juni 15-2020 19:50 PM",

            //    SeatsLeft = 50
            //},
            //    new ViewingGallery()
            //    {
            //        ViewingID = 2,

            //        Movie = new Movie()
            //        {
            //            ID = 2,
            //            Title = "Avengers:Endgame ",
            //            Type = "Action",
            //            Productionyear = "2019"
            //        },
            //        ShowTime = "Juni 15-2020 17:45 PM",

            //        SeatsLeft = 50
            //    },
            //     new ViewingGallery()
            //     {
            //         ViewingID = 3,


            //         Movie = new Movie()
            //         {
            //             ID = 3,
            //             Title = "Wonder Woman",
            //             Type = "Action",
            //             Productionyear = "2017"
            //         },
            //         ShowTime = "Juni 15-2020 19:50 PM",

            //         SeatsLeft = 50
            //     },
            //      new ViewingGallery()
            //      {
            //          ViewingID = 4,

            //          Movie = new Movie()
            //          {
            //              ID = 4,
            //              Title = "Black Panther",
            //              Type = "Drama",
            //              Productionyear = "2018"
            //          },
            //          ShowTime = "Juni 16-2020 15:00 PM",

            //          SeatsLeft = 50
            //      },
            //       new ViewingGallery()
            //       {
            //           ViewingID = 5,

            //           Movie = new Movie()
            //           {
            //               ID = 5,
            //               Title = "Lady Bird",
            //               Type = "Drama",
            //               Productionyear = "2018"
            //           },
            //           ShowTime = "Juni 16-2020 17:30 PM",
            //           SeatsLeft = 50
            //       },
            //        new ViewingGallery()
            //        {
            //            ViewingID = 6,

            //            Movie = new Movie()
            //            {
            //                ID = 6,
            //                Title = "The Irishman",
            //                Type = "Drama",
            //                Productionyear = "2019"
            //            },
            //            ShowTime = "Juni 16-2020 20:30 PM",

            //            SeatsLeft = 50
            //        }
            //);
            
        }
    }
}
