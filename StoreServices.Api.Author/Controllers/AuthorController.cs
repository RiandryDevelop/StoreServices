using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            await _mediator.Send(data);
            return Unit.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(string id)
        {
            return await _mediator.Send(new QueryFilter.AuthorUnique() { AuthorBookGuid = id });
        }
    }
}