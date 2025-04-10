using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>>
        {

        }

        public class Handler(AuthorContext context, IMapper mapper) : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _context = context;
            private readonly IMapper _mapper = mapper;

            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.AuthorBooks.ToListAsync();
                var authorDtos = _mapper.Map<List<AuthorBook>, List<AuthorDto>>(authors);
                return authorDtos;
            }
        }
    }
}
