using System.Text;

namespace StoreServices.Api.Author.Model
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public required string Name { get; set; }

        public required string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<AcademicDegree>? AcademicDegrees { get; set; }

        public required string AuthorBookGuid { get; set; }
    }
}
