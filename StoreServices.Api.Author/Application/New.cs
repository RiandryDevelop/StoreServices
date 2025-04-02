using MediatR;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistence;

namespace StoreServices.Api.Author.Application
{
    public class New
    {
        // Comando (Request)
        public class Execute : IRequest<Unit>
        {
            public required string Name { get; set; }
            public required string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        // Handler del comando
        public class Handler(AuthorContext context) : IRequestHandler<Execute, Unit>
        {
            private readonly AuthorContext _context = context;

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var author = new AuthorBook
                {
                    AuthorBookGuid = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate
                };

                _context.AuthorBooks.Add(author);
                var result = await _context.SaveChangesAsync(cancellationToken);

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el autor");
            }
        }
    }
}

