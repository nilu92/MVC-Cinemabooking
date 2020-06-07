using Lab1ASP.NetCore.BioDbContext;
using Lab1ASP.NetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.BerrasData
{
    public class BerrasDBContext : DbContext
    {
        public BerrasDBContext()
        {
        }

        public BerrasDBContext(DbContextOptions<BerrasDBContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOne<Movie>(s => s.Movie)
            //    .WithMany(g => g.Orders)
            //    .HasForeignKey(s => s.MovieID);
            modelBuilder.Seed();
        }
    }
}
