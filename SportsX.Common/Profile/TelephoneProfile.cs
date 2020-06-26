using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Repository.Entities;

namespace SportsX.Common.ProfileConfiguration
{
    public class TelephoneProfile : Profile
    {
        // Classe de configuração do automapper para Telefone
        public TelephoneProfile()
        {
            CreateMap<Telephone, TelephoneDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Number, opt => opt.MapFrom(x => x.Number))
                .ReverseMap();
        }
    }
}
