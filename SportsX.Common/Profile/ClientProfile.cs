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
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyName))
                .ForMember(x => x.CpfCnpj, opt => opt.MapFrom(x => x.CpfCnpj))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Cep, opt => opt.MapFrom(x => x.Cep))
                .ForMember(x => x.IdClassification, opt => opt.MapFrom(x => x.IdClassification))
                .ForMember(x => x.Classification, opt => opt.MapFrom(x => x.Classification))
                .ForMember(x => x.IdClientType, opt => opt.MapFrom(x => x.IdClientType))
                .ForMember(x => x.ClientType, opt => opt.MapFrom(x => x.ClientType))
                .ForMember(x => x.Telephones, opt => opt.MapFrom(x => x.Telephones))
                .ReverseMap();
        }
    }
}
