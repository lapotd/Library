using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;

namespace Library.AutoMapperProfiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<Author, AuthorForReturnDto>();
        }
    }
}
