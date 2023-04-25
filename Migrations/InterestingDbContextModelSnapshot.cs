﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_API_Interest;

#nullable disable

namespace Test_API_Interest.Migrations
{
    [DbContext(typeof(InterestingDbContext))]
    partial class InterestingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GenrePerson", b =>
                {
                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsPersonId")
                        .HasColumnType("int");

                    b.HasKey("GenresGenreId", "PersonsPersonId");

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("GenrePerson");
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GenreId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId")
                        .HasName("PK_GenreIdIdentity");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MovieId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.HasKey("MovieId")
                        .HasName("PK_MovieId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PersonId");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId")
                        .HasName("PK_PIdentity");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("GenrePerson", b =>
                {
                    b.HasOne("Test_API_Interest.DataDomain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_API_Interest.DataDomain.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Movie", b =>
                {
                    b.HasOne("Test_API_Interest.DataDomain.Entities.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_API_Interest.DataDomain.Entities.Person", "Person")
                        .WithMany("Movies")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK_Movies_Person");

                    b.Navigation("Genre");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Test_API_Interest.DataDomain.Entities.Person", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
