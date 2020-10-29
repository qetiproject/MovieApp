using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options)
            :base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Movie

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .HasMaxLength(5000)
                .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(e => e.Title)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Movie>()
              .HasOne(e => e.Director)
              .WithMany(e => e.Movies)
              .HasForeignKey(e => e.DirectorId)
              .OnDelete(DeleteBehavior.Restrict);

            //MovieActors

            modelBuilder.Entity<MovieActor>()
              .HasOne(e => e.Movie)
              .WithMany(e => e.MovieActors)
              .HasForeignKey(e => e.MovieId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovieActor>()
              .HasOne(e => e.Actor)
              .WithMany(e => e.MovieActors)
              .HasForeignKey(e => e.PersonId)
              .OnDelete(DeleteBehavior.Restrict);

            //Person

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.IsDirector)
                .HasDefaultValue(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.IsActor)
                .HasDefaultValue(false);
        }
    }
}
