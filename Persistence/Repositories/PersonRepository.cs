using Microsoft.AspNetCore.Mvc;
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
                //Person = person
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
                Genre = genre
            };
            movie.Persons.Add(person);
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
           // genre.Persons.Add(person);

            //_context.People.Update(person);
            _context.SaveChanges();

        }

        //public Person SetMovieRatings(int perId, int movId, int rating)
        //{
        //    var movie = _context.Movies.AsNoTracking()
        //                      .Include(i => i.Persons)
        //                          .Where(g => g.MovieId == movId && g.PersonId == perId)
        //                          .FirstOrDefault();
        //    if (movie is not null)
        //        movie.Rating = rating;

        //    _context.Movies.Update(movie);
        //    _context.SaveChanges();

        //    var person = movie.Persons.Where(p => p.PersonId == perId)
        //                         .FirstOrDefault();
        //    return person;
        //}



        public Person SetMovieRatings(int perId, int movId, int rating)
        {
            var movie = _context.Movies
                .Include(m => m.Persons)
                .FirstOrDefault(m => m.MovieId == movId && m.Persons.Any(p => p.PersonId == perId));

            if (movie == null)
            {
                throw new ArgumentException($"Movie with ID {movId} does not belong to person with ID {perId}");
            }

            movie.Rating = rating;
            _context.SaveChanges();

            var person = movie.Persons.FirstOrDefault(p => p.PersonId == perId);
            return person;
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
