using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Contracts.IPersistance
{
    public interface IMovie
    {
        int AddMovieLink(int genreId, int personId, string link);
        List<Movie> GetAllMovies();
        List<Movie> GetAllMoviesByPersonId(int personId);
        List<Movie> GetAllMoviesByGenreId(int genreId);
        int GetMovieRating(int personId, int movieId);
    }
}
