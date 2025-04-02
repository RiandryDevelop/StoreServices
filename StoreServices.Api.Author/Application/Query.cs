using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorBook>>
        {
           
        }

        public class Handler(AuthorContext context) : IRequestHandler<AuthorList, List<AuthorBook>>
        {
            private readonly AuthorContext _context = context;

            public async Task<List<AuthorBook>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                return await _context.AuthorBooks.ToListAsync();
            }
        }
    }
}
