using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class AuthorUnique : IRequest<AuthorBook>
        {
            public required string AuthorBookGuid { get; set; }
        }

        public class Handler(AuthorContext context) : IRequestHandler<AuthorUnique, AuthorBook>
        {
            private readonly AuthorContext _context = context;

            public async Task<AuthorBook> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBooks.Where(Author => Author.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();

                return author == null ? throw new Exception("Author not found") : author;
            }
        }
    }
}
