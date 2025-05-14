using MediatR;
using FluentValidation;
using StoreServices.Api.Book.Persistence;
using StoreServices.Api.Book.Model;

namespace StoreServices.Api.Book.Application
{
    public class New
    {
        public class Execute: IRequest
        {
            public required string Title { get; set; }
            public DateTime? PublishedDate { get; set; }
            public Guid? AuthorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title is required")
                    .Length(1, 100).WithMessage("Title must be between 1 and 100 characters");
                
                RuleFor(x => x.PublishedDate)
                    .NotEmpty().WithMessage("Published date is required");

                RuleFor(x => x.AuthorBook).NotEmpty()
                    .WithMessage("AuthorBook is required")
                    .Must(x => x != Guid.Empty).WithMessage("AuthorBook must be a valid GUID");
            }

            public class Handler(LibraryContext context) : IRequestHandler<Execute>
            {
                private readonly LibraryContext _context = context;

                public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
                {
                    var author = new LibraryMaterial
                    {
                        Title = request.Title,
                        PublishedDate = request.PublishedDate,
                        AuthorBook = request.AuthorBook,
                    };

                    _context.LibraryMaterials.Add(author);
                    var result = await _context.SaveChangesAsync(cancellationToken);

                    if (result > 0)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("Could not insert the book");
                }

                Task IRequestHandler<Execute>.Handle(Execute request, CancellationToken cancellationToken)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
