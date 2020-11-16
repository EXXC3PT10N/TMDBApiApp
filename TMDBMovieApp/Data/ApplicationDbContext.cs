using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMDBMovieApp.Models;

namespace TMDBMovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TMDBMovieApp.Models.MoviesInLists> MoviesInLists { get; set; }
        public DbSet<TMDBMovieApp.Models.Lists> Lists { get; set; }
    }
}
