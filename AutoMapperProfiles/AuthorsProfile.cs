using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;

namespace Library.AutoMapperProfiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, ReturnAuthorDto>();
        }
    }
}
