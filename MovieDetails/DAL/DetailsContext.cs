using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieDetails.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MovieDetails.DAL
{
    public class DetailsContext : DbContext
    {
        public DetailsContext() : base("DetailsContext")
        {
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}