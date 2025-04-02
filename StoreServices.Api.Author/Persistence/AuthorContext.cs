using Microsoft.EntityFrameworkCore;

namespace StoreServices.Api.Author.Persistence
{
    public class AuthorContext(DbContextOptions<AuthorContext> options) : DbContext(options) 
    {
        public DbSet<Model.AuthorBook> AuthorBooks { get; set; }
        public DbSet<Model.AcademicDegree> AcademicDegrees { get; set; }
    }
}
