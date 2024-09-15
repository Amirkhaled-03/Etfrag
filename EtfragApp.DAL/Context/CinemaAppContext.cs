using EtfragApp.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Context
{
    public class CinemaAppContextMVC : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public CinemaAppContextMVC()
        {
        }

        public CinemaAppContextMVC(DbContextOptions<CinemaAppContextMVC> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {



            builder.Entity<MovieCategory>().HasKey(mc => new { mc.MediaId, mc.CategoryId });
            builder.Entity<MovieCategory>()
                .HasOne(m => m.Movie)
                .WithMany(mc => mc.MovieCategories)
                .HasForeignKey(m => m.MediaId);
            builder.Entity<MovieCategory>()
                .HasOne(c => c.Category)
                .WithMany(mc => mc.MovieCategories)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<MovieActor>().HasKey(ma => new { ma.ActorId, ma.MovieId });
            builder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);
            builder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);


            builder.Entity<TVSeriesCategory>().HasKey(mc => new { mc.TVSeriesId, mc.CategoryId });
            builder.Entity<TVSeriesCategory>()
                .HasOne(m => m.TVSeries)
                .WithMany(mc => mc.TVSeriesCategories)
                .HasForeignKey(m => m.TVSeriesId);
            builder.Entity<TVSeriesCategory>()
                .HasOne(c => c.Category)
                .WithMany(mc => mc.TVSeriesCategories)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<TVSeriesActor>().HasKey(ma => new { ma.ActorId, ma.TVSeriesId });
            builder.Entity<TVSeriesActor>()
                .HasOne(ma => ma.TVSeries)
                .WithMany(m => m.TVSeriesActors)
                .HasForeignKey(ma => ma.TVSeriesId);
            builder.Entity<TVSeriesActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.TvSeriesActors)
                .HasForeignKey(ma => ma.ActorId);

            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }

        public DbSet<TVSeriesCategory> TVSeriesCategories { get; set; }
        public DbSet<TVSeriesActor> TVSeriesActors { get; set; }


    }


}
