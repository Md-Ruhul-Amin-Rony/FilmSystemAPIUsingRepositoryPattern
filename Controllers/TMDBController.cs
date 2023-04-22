using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_API_Interest.TMDB;
using Test_API_Interest.TMDB.Models;

namespace Test_API_Interest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TMDBController : ControllerBase
    {
        private readonly ITmdbApiClient _tmdbApiClient;

        public TMDBController(ITmdbApiClient tmdbApiClient)
        {
            _tmdbApiClient = tmdbApiClient;
        }

        [HttpGet("TMDB/GetAllGenres")]
        public async Task<ActionResult> GetAllGenres()
        {
            var genreList = _tmdbApiClient.GetAllGenre();

            if (genreList == null)
            {
                throw new ArgumentException($"Genre not found.");
            }

            return Ok(JsonConvert.SerializeObject(genreList));
        }

        [HttpGet("TMDB/AddAllGenreToLocalDB")]
        public async Task<ActionResult> AddAllGenreToLocalDB()
        {
            var genreList = _tmdbApiClient.AddAllGenreToLocalDB();

            if (genreList == null)
            {
                throw new ArgumentException($"Genre not found.");
            }

            return Ok(JsonConvert.SerializeObject(genreList.Result));
        }

    } 


}
