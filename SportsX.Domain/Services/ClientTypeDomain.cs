using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Services
{
    public class ClientTypeDomain : IClientTypeDomain
    {
        protected readonly IClientTypeRepository _clientTypeRepository;
        protected readonly IMapper _mapper;
        public ClientTypeDomain(IClientTypeRepository clientTypeRepository, IMapper mapper) 
        {
            _clientTypeRepository = clientTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientTypeDto>> GetAllAsync()
        {
            var response = await _clientTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientTypeDto>>(response);
        }

        public async Task<ClientTypeDto> GetByIdAsync(int id)
        {
            var response = await _clientTypeRepository.GetByIdAsync(id);
            return _mapper.Map<ClientTypeDto>(response);
        }
    }
}
