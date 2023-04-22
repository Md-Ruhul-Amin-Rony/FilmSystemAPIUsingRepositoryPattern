using Test_API_Interest.DataDomain.Entities;
using Test_API_Interest.TMDB.Models;

namespace Test_API_Interest.TMDB
{
    public interface ITmdbApiClient
    {
        Task<GenreList> GetAllGenre();
        Task<GenreList> AddAllGenreToLocalDB();
    }
}
