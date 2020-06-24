using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Repository.Entities;

namespace SportsX.Common.ProfileConfiguration
{
    public class ClientProfile : Profile
    {
        // Classe de configuração do automapper para Cliente
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ReverseMap();
        }
    }
}
