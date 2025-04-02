using MediatR;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class AuthorUnique : IRequest<AuthorBook>
        {
            public Guid AuthorBookId { get; set; }
        }

        public class Handler(AuthorContext context) : IRequestHandler<AuthorUnique, AuthorBook>
        {
            private readonly AuthorContext _context = context;

            public async Task<AuthorBook> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
               var author =  await _context.AuthorBooks.FindAsync(request.AuthorBookId);

                return author == null ? throw new Exception("Author not found") : author;
            }
        }
    }
}
