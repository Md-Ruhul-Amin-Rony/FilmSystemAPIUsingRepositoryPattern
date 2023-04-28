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
                Genre = genre
            };
            movie.Persons.Add(person);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie.MovieId;
        }

        public List<Movie> GetAllMovies()
        {
            var allmovies = _context.Movies.AsNoTracking()
                                 .Include(i => i.Persons)
                                 .Include(i => i.Genre)
                                  .ToList();
            return allmovies;
        }

        public List<Movie> GetAllMoviesByGenreId(int genreId)
        {
            var allmovies = _context.Movies.AsNoTracking()
                                 .Include(i => i.Persons)
                                 .Include(i => i.Genre)
                                     .Where(g => g.Genre.GenreId == genreId)
                                     .ToList();
            return allmovies;
        }

        public List<Movie> GetAllMoviesByPersonId(int personId)
        {
            var allmovies = _context.Movies.AsNoTracking()
                                             .Include(i => i.Persons)
                                             .Include(i => i.Genre)
                                                 //.Where(g => g.Person.PersonId == personId)
                                                 .ToList();
            return allmovies;
        }
        public List<Movie> GetAllRatingssByPersonId(int personId)
        {
            var personMovies = new List<Movie>();
            var allmovies = _context.Movies.AsNoTracking()
                                             .Include(i => i.Persons)
                                             .Include(i => i.Genre)
                                                 //.Where(g => g.Persons.Where(p => p.PersonId == personId).Select(x=> x))
                                                 .ToList();


            foreach (var item in allmovies)
            {
                foreach (var p in item.Persons.ToList())
                {
                    if (p.PersonId == personId)
                    {
                        personMovies.Add(item);
                    }
                }

            }
            return personMovies;
        }
        public int GetMovieRating(int personId, int movieId)
            //public int GetMovieRating(int personId)

        {
            var rat = 0;
            var movies = _context.Movies.AsNoTracking()
                                                //.Include(i=>i.mo)
                                                .Include(x => x.Persons)
                                                .ToList();

            if (movies == null)
            {
                throw new ArgumentNullException("No movie found");
            }

            foreach (var item in movies)
            {
                if (item.MovieId == movieId)
                {
                    foreach (var p in item.Persons.ToList())
                    {
                        if (p.PersonId == personId)
                        {
                            rat = (int)item.Rating;
                        }
                    }
                }
 
            }
            // .Where(g => g.Person.PersonId == personId )
            // .ToList();
            //// .FirstOrDefault();

    
            return rat;
        }
    }
}
