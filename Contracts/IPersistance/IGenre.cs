using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Contracts.IPersistance
{
    public interface IGenre
    {
        int AddGenreForPerson(string title, string description);
        List<Genre> GetAllGenresByPeronID(int personId);
        List<Genre> GetAllGenres();
    }
}
