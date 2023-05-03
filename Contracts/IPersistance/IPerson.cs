using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.Contracts.IPersistance
{
    public interface IPerson
    {
        int AddPerson(string name, string email);
        void AddGenre(int personId, string title, string description);
        void AddMovieLink(int genreId, int personId, string link);
        List<Person> GetAllPersons();
        void AddToNewGenre(int personId,int genreId);
         
       // Person GetPersonByID(int personId);

        Person SetMovieRatings(int perId, int moId, int rating);
    }
}
