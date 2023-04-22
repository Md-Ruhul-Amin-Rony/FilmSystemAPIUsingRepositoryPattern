using Newtonsoft.Json;
using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.TMDB.Models
{

    public class GenreList
    {
        [JsonProperty("genres")]
        public IEnumerable<TGenre> Genres { get; set; }
    }
}
