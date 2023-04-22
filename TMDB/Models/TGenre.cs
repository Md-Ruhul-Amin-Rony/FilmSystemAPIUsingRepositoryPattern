using Newtonsoft.Json;

namespace Test_API_Interest.TMDB.Models
{
    public class TGenre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
