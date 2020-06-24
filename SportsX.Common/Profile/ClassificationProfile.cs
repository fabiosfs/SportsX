using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Repository.Entities;

namespace SportsX.Common.ProfileConfiguration
{
    public class ClassificationProfile : Profile
    {
        public ClassificationProfile()
        {
            CreateMap<Classification, ClassificationDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ReverseMap();
        }
    }
}
