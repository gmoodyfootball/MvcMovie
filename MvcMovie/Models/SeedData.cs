using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2005-2-11"),
                         Genre = "Comedy",
                         Rating = "G",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "The Best Two Years",
                         ReleaseDate = DateTime.Parse("2004-3-13"),
                         Genre = "Comedy",
                         Rating = "G",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "The Saratov Approach",
                         ReleaseDate = DateTime.Parse("2014-2-23"),
                         Genre = "Suspense",
                         Rating = "PG-13",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "The Singles Ward",
                       ReleaseDate = DateTime.Parse("2002-4-15"),
                       Genre = "Cringey",
                       Rating = "G",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}