using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class AuthorUnique : IRequest<AuthorDto>
        {
            public required string AuthorBookGuid { get; set; }
        }

        public class Handler(AuthorContext context, IMapper mapper) : IRequestHandler<AuthorUnique, AuthorDto>
        {
            private readonly AuthorContext _context = context;
            private readonly IMapper _mapper = mapper;

            public async Task<AuthorDto> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBooks.Where(Author => Author.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();
                var authorDto = _mapper.Map<AuthorDto>(author);

                return authorDto == null ? throw new Exception("Author not found") : authorDto;
            }
        }
    }
}
