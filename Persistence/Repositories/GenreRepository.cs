using Microsoft.EntityFrameworkCore;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Persistence.Repositories
{
    public class GenreRepository : IGenre
    {
        private InterestingDbContext _context;
        public GenreRepository(InterestingDbContext dbContext)
        {
            _context = dbContext;
        }

        public int AddGenreForPerson(string title, string description)
        {
            //var person = _context.People.Where(p => p.PersonId == personId).FirstOrDefault();
            var genre = new Genre {
                Title = title,
                Description = description,
            };
           _context.Genres.Add(genre);
           _context.SaveChanges();
            return genre.GenreId;
        }

        public List<Genre> GetAllGenres()
        {
            var allGenres = _context.Genres.AsNoTracking()
                                            .Include(i => i.Person)
                                            .Include(i => i.Movies)
                                            .ToList();
            return allGenres;
        }

        public List<Genre> GetAllGenresByPeronID(int personId)
        {
            var allGenres = _context.Genres.AsNoTracking()
                                                        .Include(i => i.Person)
                                                        .Include(i => i.Movies)
                                                            .Where(g => g.Person.PersonId == personId)
                                                            .ToList();
            return allGenres;
        }
    }
}
