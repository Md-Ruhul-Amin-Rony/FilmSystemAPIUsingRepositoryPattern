using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;
using Test_API_Interest.Models;

namespace Test_API_Interest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> AddPerson([FromBody] AddPersonCommandRequest model)
        {
            var addedPersonID = _person.AddPerson(model.Name, model.Email);
            return Ok(addedPersonID);
        }

        //[HttpPost("Add/Genre")]
        //public async Task<ActionResult> PersonAddGenre([FromBody] PersonAddGenreCommandRequest model)
        //{
        //    _person.AddGenre(model.PersonId, model.Title,model.Description);
        //    return Ok();
        //}

        [HttpPost("Add/Movie")]
        public async Task<ActionResult> PersonAddMovie([FromBody] PersonAddMovieLinkCommandRequest model)
        {
            _person.AddMovieLink(model.GenreId, model.PersonId, model.Link);
            return Ok();
        }

        [HttpGet("GetAllPeople")]
        public async Task<ActionResult> GetAllPersonal()
        {
           var people =  _person.GetAllPersons();
           List<object> ViewModel = new List<object>();
            foreach (var per in people)
            {
                var response = new 
                {
                    PersonId = per.PersonId,
                   name = per.Name,
                   email = per.Email,
                   // genres = new List<dynamic>(),
                    //movies = new List<dynamic>()
                };
                //foreach (var item in per.Genres)
                //{
                //    response.genres.Add(new
                //    {
                //        id = item.GenreId,
                //        title= item.Title,
                //        description = item.Description,
                //    });
                //}
                //foreach (var item in per.Movies)
                //{
                //    response.movies.Add(new
                //    {
                //        id = item.MovieId,
                //        link = item.Link,
                //        ratings = item.Rating
                //    });
                //}

                ViewModel.Add(response);
                
            }
            return Ok(ViewModel);
            
        }

        [HttpGet("GetAllPeopleDetails")]
        public async Task<ActionResult> GetAllPersonalDetails()
        {
            var people = _person.GetAllPersons();
            List<object> ViewModel = new List<object>();
            foreach (var per in people)
            {
                var response = new
                {
                    PersonId = per.PersonId,
                    name = per.Name,
                    email = per.Email,
                     genres = new List<dynamic>(),
                    movies = new List<dynamic>()
                };
                foreach (var item in per.Genres)
                {
                    response.genres.Add(new
                    {
                        id = item.GenreId,
                        title = item.Title,
                        description = item.Description,
                    });
                }
                foreach (var item in per.Movies)
                {
                    response.movies.Add(new
                    {
                        id = item.MovieId,
                        link = item.Link,
                        ratings = item.Rating
                    });
                }

                ViewModel.Add(response);

            }
            return Ok(ViewModel);

        }






        [HttpPost("AddToNewGenre")]
        public async Task<ActionResult> AddToNewGenre([FromBody] AddToNewGenreCommandRequest model)
        {
            //_person.AddToNewGenre( model.PersonId, model.GenreId);
            //return Ok();

            var addedGenre = _person.AddToNewGenre(model.PersonId, model.GenreId);
           
            return Ok(addedGenre);
        }

        //[HttpGet("Get/Person/{personId}")]
        //public async Task<ActionResult> GetPersonById( int personId)
        //{
        //   var per = _person.GetPersonByID(personId);

        //    //object ViewModel = new object();
      
        //        var response = new
        //        {
        //            PersonId = per.PersonId,
        //            name = per.Name,
        //            email = per.Email,
        //            genres = new List<dynamic>(),
        //            movies = new List<dynamic>()
        //        };
        //        foreach (var item in per.Genres)
        //        {
        //            response.genres.Add(new
        //            {
        //                id = item.GenreId,
        //                title = item.Title,
        //                description = item.Description,
        //            });
        //        }
        //        foreach (var item in per.Movies)
        //        {
        //            response.movies.Add(new
        //            {
        //                id = item.MovieId,
        //                link = item.Link,
        //                ratings = item.Rating
        //            });
        //        }
            
        //    return Ok(response);
        //}

        [HttpPost("Add/MovieRatings")]
        public async Task<ActionResult> AddMovieRatings([FromBody] AddMovieRatingsCommandRequest model)
        {
          var per =  _person.SetMovieRatings(model.PersonId, model.MovieId, model.Rating);

            var ViewModel = new
            {
                PersonId = per.PersonId,
                name = per.Name,
                email = per.Email,
                movies = new List<dynamic>()
            };
            foreach (var item in per.Movies)
            {
                ViewModel.movies.Add(new
                {
                    id = item.MovieId,
                    link = item.Link,
                    ratings = item.Rating
                });
            }

            return Ok(ViewModel);
        }
    }
}
