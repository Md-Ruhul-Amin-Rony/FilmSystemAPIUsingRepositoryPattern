using System.ComponentModel.DataAnnotations;

namespace Test_API_Interest.DataDomain.Entities
{
    public class Person
    {
        public Person()
        {
            Genres = new HashSet<Genre>();
            Movies = new HashSet<Movie>();
        }
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
