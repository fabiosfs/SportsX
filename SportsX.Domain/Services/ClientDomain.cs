using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Services
{
    public class ClientDomain : IClientDomain
    {
        // Classe contendo a regra de negócio da Cliente
        protected readonly IClientRepository _clientRepository;
        protected readonly IMapper _mapper;
        public ClientDomain(IClientRepository clientRepository, IMapper mapper) 
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync(int? idClientType)
        {
            var response = await _clientRepository.GetAllAsync(idClientType);
            return _mapper.Map<IEnumerable<ClientDto>>(response);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var response = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(response);
        }

        public async Task<ClientDto> InsertAsync(ClientDto client)
        {
            var entity = _mapper.Map<Client>(client);
            var response = await _clientRepository.InsertAsync(entity);
            return _mapper.Map<ClientDto>(response);
        }

        public async Task<ClientDto> UpdateAsync(ClientDto client)
        {
            var entity = _mapper.Map<Client>(client);
            var response = await _clientRepository.UpdateAsync(entity);
            return _mapper.Map<ClientDto>(response);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
}
