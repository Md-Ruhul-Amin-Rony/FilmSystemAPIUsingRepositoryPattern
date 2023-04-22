using Newtonsoft.Json;
using Test_API_Interest.DataDomain.Entities;

namespace Test_API_Interest.TMDB.Models
{
    public class MovieList
    {
        [JsonProperty("results")]
        public IEnumerable<TMovie> Results { get; set; }
    }
}
