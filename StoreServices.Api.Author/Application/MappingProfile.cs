using AutoMapper;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorBook, AuthorDto>();
        CreateMap<AuthorDto, AuthorBook>();
    }
}
