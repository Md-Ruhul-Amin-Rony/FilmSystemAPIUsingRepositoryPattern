using Microsoft.EntityFrameworkCore;
using Test_API_Interest.DataDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Test_API_Interest
{
    public class InterestingDbContext : DbContext
    {

        public InterestingDbContext(DbContextOptions<InterestingDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasKey(p => p.PersonId)
                      .HasName("PK_PIdentity");

               entity.Property(p => p.PersonId)
                     .HasColumnName("PersonId")
                     .ValueGeneratedOnAdd();


                //.HasDefaultValueSql("(newid())");

                //.ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                      .HasName("PK_GenreIdIdentity");

                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                      .HasColumnName("GenreId")
                      .ValueGeneratedOnAdd();

                //entity.Property(e => e.Person)
                //      .HasColumnName("PersonId")
                //      .;

                //entity.HasOne(e => e.Person)
                //      .WithMany(w => w.Genres)
                //      .HasForeignKey(d => d.PersonId)
                //      .OnDelete(DeleteBehavior.ClientSetNull)
                //      .HasConstraintName("FK_Genres_Person");
            });


            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                      .HasName("PK_MovieId");

                entity.ToTable("Movie");

                entity.Property(e => e.MovieId)
                      .HasColumnName("MovieId")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Rating)
                      .HasColumnName("Rating")
                      .HasMaxLength(10);

                //entity.HasOne(e => e.Person)
                //      .WithMany(w => w.Movies)
                //      .HasForeignKey(d => d.PersonId)
                //      .OnDelete(DeleteBehavior.ClientSetNull)
                //      .HasConstraintName("FK_Movies_Person");
            });

           // modelBuilder.Entity<Genre>()
           //.Property(g => g.GenreId)
           //.ValueGeneratedOnAdd();

           // modelBuilder.Entity<Genre>()
           //.HasOne(c => c.Person)
           //.WithMany(c => c.Genres)
           //.OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<Movie>()
           //.Property(m => m.MovieId)
           //.ValueGeneratedOnAdd();

           // modelBuilder.Entity<Movie>()
           //    .HasOne(c => c.Genre)
           //    .WithMany(c => c.Movies)
           //    .OnDelete(DeleteBehavior.NoAction);

           // modelBuilder.Entity<Movie>()
           //  .HasOne(c => c.Person)
           //  .WithMany(c => c.Movies)
           //  .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
