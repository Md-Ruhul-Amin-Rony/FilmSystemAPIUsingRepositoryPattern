using Microsoft.EntityFrameworkCore;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Persistence.Repositories
{
    public class PersonRepository : IPerson
    {
        private InterestingDbContext _context;
        public PersonRepository(InterestingDbContext dbContext)
        {
            _context = dbContext;
        }
        public int AddPerson(string name, string email)
        {
            var person = new Person
            {
                Name = name,
                Email = email
            };
            _context.People.Add(person);
            _context.SaveChanges();
            return person.PersonId;
        }

        public void AddGenre(int personId, string title, string description)
        {
            var person = _context.People.Where(p => p.PersonId == personId).FirstOrDefault();
            var genre = new Genre
            {
                Title = title,
                Description = description,
                Person = person
            };
            person.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void AddMovieLink(int genreId, int personId, string link)
        {
            var genre = _context.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
            var person = _context.People.Where(p => p.PersonId == personId).FirstOrDefault();
            var movie = new Movie
            {
                Link = link,
                Person = person,
                Genre = genre
            };
            person.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Person> GetAllPersons()
        {
            var allPersonal = _context.People.AsNoTracking()
                                                          .Include(x=> x.Genres)
                                                          .Include(x => x.Movies)
                                                          .OrderBy(n => n.Name)
                                                          .ToList();
            return allPersonal;
        }

        public void AddToNewGenre(int personId, int genreId)
        {
            var genre = _context.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
            var person = _context.People.Where(p => p.PersonId == personId).FirstOrDefault();

            person.Genres.Add(genre);
            _context.SaveChanges();

        }

        public Person SetMovieRatings(int perId, int movId, int rating)
        {
            var movie = _context.Movies.AsNoTracking()
                              .Include(i => i.Person)
                                  .Where(g => g.MovieId == movId && g.PersonId == perId)
                                  .FirstOrDefault();
            if (movie is not null)
                 movie.Rating = rating;

            _context.Movies.Update(movie);
            _context.SaveChanges();

            //var person = _context.People.AsNoTracking()
            //                     .Include(i => i.Genres)
            //                     .Include(i => i.Movies)
            //                     .Where(p => p.PersonId == movie.PersonId)
            //                     .FirstOrDefault();
            

            return movie.Person;
        }

        public Person GetPersonByID(int personId)
        {
            var person = _context.People.AsNoTracking()
                                 .Include(i => i.Genres)
                                 .Include(i => i.Movies)
                                 .Where(p => p.PersonId == personId)
                                 .FirstOrDefault() ;

            return person;
                               
        }
    }
}
