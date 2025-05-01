namespace StoreServices.Api.Book.Model
{
    public class LibraryMaterial
    {
        public Guid LibraryMaterialId { get; set; }
        public required string Title { get; set; }
        public DateTime? PublishedDate { get; set; }

        public Guid? AuthorBook { get; set; }
    }
}
