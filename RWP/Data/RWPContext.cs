using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RWP.Models;

namespace RWP.Data
{
    public class RWPContext : DbContext
    {
        public RWPContext (DbContextOptions<RWPContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)"); // Указываем тип столбца decimal с точностью 18 и масштабом 2
            //modelBuilder.Entity<Movie>().HasData(
            //new Movie() { Id = 1, Genre = "Apple iPad",Title = "Apple iPad", ReleaseDate = DateTime.Now, Price = 1000 },
            //new Movie() { Id = 2, Genre = "Samsung Smart TV", Title = "Apple iPad", ReleaseDate = DateTime.Now, Price = 1500 },
            //new Movie() { Id = 3, Genre = "Nokia 130", Title = "Apple iPad", ReleaseDate= DateTime.Now , Price = 1200 });
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
