using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;
using Test_API_Interest.Models;

namespace Test_API_Interest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenre _genre;

        public GenreController(IGenre genre)
        {
            _genre = genre;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> AddGenre([FromBody] AddGenreForPersonCommandRequest model)
        {
            var addedGenre = _genre.AddGenreForPerson(model.Title,model.Description);
            return Ok(addedGenre);
        }

        [HttpGet("GetAllGenreByPersonID/{personId}")]
        public async Task<ActionResult> GetAllGenreByPersonID(int personId)
        {
            var per = _genre.GetAllGenresByPeronID(personId);
            


           // object ViewModel = new object();

            var response = new
            {
                PersonId = per.PersonId,
                name = per.Name,
                email = per.Email,
                genres = new List<dynamic>()
               // movies = new List<dynamic>()
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
            //foreach (var item in per.Movies)
            //{
            //    response.movies.Add(new
            //    {
            //        id = item.MovieId,
            //        link = item.Link,
            //        ratings = item.Rating
            //    });
            //}

            return Ok(response);

        }


        [HttpGet("GetAllGenres")]
        public async Task<ActionResult> GetAllGenres()
        {
            var genres = _genre.GetAllGenres();
            List<object> ViewModel = new List<object>();
            foreach (var per in genres)
            {
                var response = new
                {
                    GenreId = per.GenreId,
                    title = per.Title,
                    description = per.Description,
                    //person = new List<dynamic>(),

                    //{
                    //    id = per.Person.PersonId,
                    //    name = per.Person.Name,
                    //    email = per.Person.Email
                    //},
                    //movies = new List<dynamic>()
                };
                //foreach (var item in per.Persons)
                //{
                //    response.person.Add(new
                //    {
                //        id = item.PersonId,
                //        name = item.Name,
                //        email = item.Email
                //    }
                //        );

                //}

                //foreach (var item in per.Movies)
                //{
                //    response.movies.Add(new
                //    {
                //        id = item.MovieId,
                //        link = item.Link
                //    });
                //}

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }

    }
}
