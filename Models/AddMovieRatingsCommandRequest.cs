namespace Test_API_Interest.Models
{
    public class AddMovieRatingsCommandRequest
    {
        public int PersonId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }
    }
}
