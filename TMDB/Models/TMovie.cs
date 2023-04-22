using Newtonsoft.Json;

namespace Test_API_Interest.TMDB.Models
{
    public class TMovie
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
    }
}
