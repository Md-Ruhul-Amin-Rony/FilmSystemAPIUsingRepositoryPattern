using Microsoft.EntityFrameworkCore;
using System;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Persistence.Repositories
{
    public class MovieRepository : IMovie
    {
        private InterestingDbContext _context;
        public MovieRepository(InterestingDbContext dbContext)
        {
            _context = dbContext;
        }

        public int AddMovieLink(int genreId, int personId, string link)
        {
            var genre = _context.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
            var person = _context.People.Where(p => p.PersonId == personId).FirstOrDefault();
            var movie = new Movie
            {
                Link = link,
                Person = person,
                Genre = genre
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie.MovieId;
        }

        public List<Movie> GetAllMovies()
        {
            var allmovies = _context.Movies.AsNoTracking()
                                 .Include(i => i.Person)
                                 .Include(i => i.Genre)
                                  .ToList();
            return allmovies;
        }

        public List<Movie> GetAllMoviesByGenreId(int genreId)
        {
            var allmovies = _context.Movies.AsNoTracking()
                                 .Include(i => i.Person)
                                 .Include(i => i.Genre)
                                     .Where(g => g.Genre.GenreId == genreId)
                                     .ToList();
            return allmovies;
        }

        public List<Movie> GetAllMoviesByPersonId(int personId)
        {
            var allmovies = _context.Movies.AsNoTracking()
                                             .Include(i => i.Person)
                                             .Include(i => i.Genre)
                                                 .Where(g => g.Person.PersonId == personId)
                                                 .ToList();
            return allmovies;
        }

        public int GetMovieRating(int personId, int movieId)
        {
            var movie = _context.Movies.AsNoTracking()
                                             
                                                 .Where(g => g.Person.PersonId == personId && g.MovieId==movieId)
                                                 .FirstOrDefault();

            if (movie==null)
            {
                throw new ArgumentNullException("No movie found");
            }
            return (int)movie.Rating;
        }
    }
}
