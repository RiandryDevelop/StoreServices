
namespace StoreServices.Api.Author.Application
{
    public class AuthorDto
    {
        public int AuthorBookId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public required string AuthorBookGuid { get; set; }
    }
}
