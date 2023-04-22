using Microsoft.AspNetCore.Mvc;
using Test_API_Interest.Contracts.IPersistance;
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
            var genres = _genre.GetAllGenresByPeronID(personId);
            List<object> ViewModel = new List<object>();
            foreach (var per in genres)
            {
                var response = new
                {
                    GenreId = per.GenreId,
                    title = per.Title,
                    description = per.Description,
                    person = new
                    {
                        id = per.Person.PersonId,
                        name = per.Person.Name,
                        email = per.Person.Email
                    },
                    movies = new List<dynamic>()
                };
                
                foreach (var item in per.Movies)
                {
                    response.movies.Add(new
                    {
                        id = item.MovieId,
                        link = item.Link
                    });
                }

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
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
                    person = new
                    {
                        id = per.Person.PersonId,
                        name = per.Person.Name,
                        email = per.Person.Email
                    },
                    movies = new List<dynamic>()
                };

                foreach (var item in per.Movies)
                {
                    response.movies.Add(new
                    {
                        id = item.MovieId,
                        link = item.Link
                    });
                }

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }

    }
}
