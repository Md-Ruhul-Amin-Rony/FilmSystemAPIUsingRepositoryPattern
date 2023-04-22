namespace Test_API_Interest.Models
{
    public class AddMovieLinkWithGenreAndPersonCommandRequest
    {
        public int PersonId { get; set; }
        public int GenreId { get; set; }
        public string Link { get; set; }
    }
}
