using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Test_API_Interest.DataDomain.Entities
{
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
            Persons= new HashSet<Person>();
        }
       
        public int GenreId { get; set; }
        

        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Movie> Movies { get;}
        public virtual ICollection<Person> Persons { get;}
       
    }
}
