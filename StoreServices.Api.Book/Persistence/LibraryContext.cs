using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;

namespace StoreServices.Api.Book.Persistence
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {
        public DbSet<LibraryMaterial> LibraryMaterials { get; set; }
    }
}
