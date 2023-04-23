using System.Collections.Generic;
using System;
using Test_API_Interest.DataDomain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Test_API_Interest.TMDB.Models;
using Microsoft.EntityFrameworkCore;
using Test_API_Interest.Contracts.IPersistance;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Test_API_Interest.TMDB
{
    public class TmdbApiClient : ITmdbApiClient
    {
        public IConfiguration Configuration { get; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        private readonly HttpClient _httpClient;
        private InterestingDbContext _context;

        public TmdbApiClient(HttpClient httpClient, IConfiguration configuration, InterestingDbContext dbContext)
        {
            _httpClient = httpClient;
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            BaseUrl = Configuration.GetConnectionString("TMDBURL");
            ApiKey = Configuration.GetConnectionString("APIKEY");
            _context = dbContext;
        }

        public async Task<GenreList> GetAllGenre()
        {
            string getAllUrl = "/genre/movie/list";
            var response = await _httpClient.GetAsync($"{BaseUrl}{getAllUrl}?api_key={ApiKey}");
            var content = await response.Content.ReadAsStringAsync();
            var genreList = JsonConvert.DeserializeObject<GenreList>(content);
            //var targetGenre = genreList.Genres.FirstOrDefault(g => g.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));

            if (genreList == null)
            {
                throw new ArgumentException($"Genre not found.");
            }

            return genreList;
        }

        public async Task<GenreList> AddAllGenreToLocalDB()
        {
            var genresFromTMDB = await GetAllGenre();

            if (genresFromTMDB == null)
            {
                throw new ArgumentException($"Genre not found To add in Local DB.");
            }
            foreach (var item in genresFromTMDB.Genres)
            {

                var myLocalGenre = new Genre()
                {
                    Title = item.Name
                };
                _context.Genres.Add(myLocalGenre);
            }
            _context.SaveChanges();

            return genresFromTMDB;
        }

        public async Task<MovieList> GetMoviesByGenre(int genreId)
        {
            string getAllUrl = "/discover/movie";
            string url = $"{BaseUrl}{getAllUrl}?api_key={ApiKey}&with_genres={genreId}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var movieList = JsonConvert.DeserializeObject<MovieList>(content);
            //var targetGenre = genreList.Genres.FirstOrDefault(g => g.Name.Equals(genre, StringComparison.OrdinalIgnoreCase));

            if (movieList == null)
            {
                throw new ArgumentException($"Genre not found.");
            }

            return movieList;
        }
    }


}
