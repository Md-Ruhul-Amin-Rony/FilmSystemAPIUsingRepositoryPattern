using Microsoft.AspNetCore.Mvc;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.DataDomain.Entities;
using Test_API_Interest.Models;

namespace Test_API_Interest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movie;

        public MovieController(IMovie movie)
        {
            _movie = movie;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> AddMovieLink([FromBody] AddMovieLinkWithGenreAndPersonCommandRequest model)
        {
            var addedMovie = _movie.AddMovieLink(model.GenreId, model.PersonId, model.Link);
            return Ok(addedMovie);
        }

        [HttpGet("GetAllMoviesByPersonId/{personId}")]
        public async Task<ActionResult> GetAllMoviesByPersonId(int personId)
        {
            var movies = _movie.GetAllMoviesByPersonId(personId);
            List<object> ViewModel = new List<object>();
            foreach (var per in movies)
            {
                var response = new
                {
                    MovieId = per.MovieId,
                    link = per.Link,
                    //person = new
                    //{
                    //    id = per.Person.PersonId,
                    //    name = per.Person.Name,
                    //    email = per.Person.Email
                    //},
                    //genre = new 
                    //{ 
                    //  id = per.Genre.GenreId,
                    //  title = per.Genre.Title,
                    //  description = per.Genre.Description
                    //}
                };

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }

        [HttpGet("GetAllMoviesByGenreId/{genreId}")]
        public async Task<ActionResult> GetAllGenreByGenreId(int genreId)
        {
            var movies = _movie.GetAllMoviesByGenreId(genreId);
            List<object> ViewModel = new List<object>();
            foreach (var per in movies)
            {
                var response = new
                {
                    MovieId = per.MovieId,
                    link = per.Link,
                    person = new
                    {
                        id = per.Person.PersonId,
                        name = per.Person.Name,
                        email = per.Person.Email
                    },
                    genre = new
                    {
                        id = per.Genre.GenreId,
                        title = per.Genre.Title,
                        description = per.Genre.Description
                    }
                };

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }

        [HttpGet("GetAllMovies")]
        public async Task<ActionResult> GetAllMovies()
        {
            var movies = _movie.GetAllMovies();
            List<object> ViewModel = new List<object>();
            foreach (var per in movies)
            {
                var response = new
                {
                    MovieId = per.MovieId,
                    link = per.Link,
                    person = new
                    {
                        id = per.Person.PersonId,
                        name = per.Person.Name,
                        email = per.Person.Email
                    },
                    genre = new
                    {
                        id = per.Genre.GenreId,
                        title = per.Genre.Title,
                        description = per.Genre.Description
                    }
                };

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }
        [HttpGet("GetMoviesRating/{personId}/{movieId}")]
        public async Task<ActionResult> GetMovieRating(int personId,int movieId)
        //[HttpGet("GetMoviesRating/{personId}")]
        //public async Task<ActionResult> GetMovieRating(int personId)

        {
            //var movies= _movie.GetAllMoviesByPersonId(personId);
            var movieRating = _movie.GetMovieRating(personId,movieId);
            //List<object> ViewModel = new List<object>();
            //foreach (var per in movies)
            //{
            //    var response = new
            //    {
            //        MovieId = per.MovieId,
            //        link = per.Link,
            //        person = new
            //        {
            //            id = per.Person.PersonId,
            //            name = per.Person.Name,
            //            email = per.Person.Email
            //        },
            //        genre = new
            //        {
            //            id = per.Genre.GenreId,
            //            title = per.Genre.Title,
            //            description = per.Genre.Description
            //        }
            //    };

            //    ViewModel.Add(response);
            //}
            return Ok(movieRating);
        }
        [HttpGet("GetAllRatingsByPersonId/{personId}")]
        public async Task<ActionResult> GetAllRatingssByPersonId(int personId)
        {
            var movies = _movie.GetAllMoviesByPersonId(personId);
            List<object> ViewModel = new List<object>();
            foreach (var per in movies)
            {
                var response = new
                {
                    MovieId = per.MovieId,
                    link = per.Link,
                    Rating = per.Rating,
                    //person = new
                    //{
                    //    id = per.Person.PersonId,
                    //    name = per.Person.Name,
                    //    email = per.Person.Email
                    //},
                    //genre = new
                    //{
                    //    id = per.Genre.GenreId,
                    //    title = per.Genre.Title,
                    //    description = per.Genre.Description
                    //}
                };

                ViewModel.Add(response);
            }
            return Ok(ViewModel);
        }
    }
}
