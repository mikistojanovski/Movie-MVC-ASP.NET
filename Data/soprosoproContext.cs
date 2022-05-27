using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using soprosopro    .Areas.Identity.Data;
using soprosopro.Models;


namespace soprosopro.Models
{
    public class soprosoproContext : IdentityDbContext<soprosoproUser>
    {
        public soprosoproContext (DbContextOptions<soprosoproContext> options)
            : base(options)
        {
        }

        public DbSet<soprosopro.Models.Movie>? Movie { get; set; }

        public DbSet<soprosopro.Models.Genre>? Genre { get; set; }

        public DbSet<soprosopro.Models.Person>? Person { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<soprosopro.Models.MovieGenres>? MovieGenres { get; set; }
        public DbSet<soprosopro.Models.MovieActors>? MovieActors { get; set; }
        public DbSet<soprosopro.Models.MovieDirectors>? MovieDirectors { get; set; }
        public DbSet<soprosopro.Models.MovieProducers>? MovieProducers { get; set; }

        public DbSet< ClientMovies>? ClientMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<Genre>().ToTable("Genre");
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Client>().ToTable("Client");
            builder.Entity<MovieGenres>().ToTable("MovieGenres");
            builder.Entity<MovieDirectors>().ToTable("MovieDirectors");
            builder.Entity<MovieActors>().ToTable("MovieActors");
            builder.Entity<MovieProducers>().ToTable("MovieProducers");

            builder.Entity<Movie>()
                 .HasOne<Client>(p => p.Client)
                 .WithMany(p => p.Movies)
                 .HasForeignKey(p => p.ClientId);

            builder.Entity<MovieGenres>()
            .HasOne<Movie>(p => p.Movie)
            .WithMany(p => p.Genres)
            .HasForeignKey(p => p.MovieId);

            builder.Entity<MovieGenres>()
         .HasOne<Genre>(p => p.Genres)
         .WithMany(p => p.Movies)
         .HasForeignKey(p => p.GenreId);

            builder.Entity<MovieActors>()
            .HasOne<Movie>(p => p.Movie)
            .WithMany(p => p.Actors)
            .HasForeignKey(p => p.MovieId);
            //.HasPrincipalKey(p => p.Id);

            builder.Entity<MovieProducers>()
                 .HasOne<Movie>(p => p.Movie)
                 .WithMany(p => p.Producers)
                 .HasForeignKey(p => p.MovieId);

            builder.Entity<MovieDirectors>()
          .HasOne<Movie>(p => p.Movie)
          .WithMany(p => p.Directors)
          .HasForeignKey(p => p.MovieId);
            //.HasPrincipalKey(p => p.Id);

            builder.Entity<MovieActors>()
           .HasOne<Person>(p => p.Actor)
           .WithMany(p => p.AM)
           .HasForeignKey(p => p.ActorId);
            //.HasPrincipalKey(p => p.Id);

            builder.Entity<MovieProducers>()
                 .HasOne<Person>(p => p.Producer)
                 .WithMany(p => p.PM)
                 .HasForeignKey(p => p.ProducerId);

            builder.Entity<MovieDirectors>()
          .HasOne<Person>(p => p.Director)
          .WithMany(p => p.DM)
          .HasForeignKey(p => p.DirectorId);
            //.HasPrincipalKey(p => p.Id);
            base.OnModelCreating(builder);
        }
    }
}
