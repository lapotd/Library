using AutoMapper;
using Library.Entities;
using Library.Models.ReturnDto;

namespace Library.AutoMapperProfiles
{
    public class PublishersProfile : Profile
    {
        public PublishersProfile()
        {
            CreateMap<CreatePublisherRequest, Publisher>();
            CreateMap<Publisher, PublisherForReturnDto>();
        }
    }
}
