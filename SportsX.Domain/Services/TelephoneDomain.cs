using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Domain.Services
{
    public class TelephoneDomain : ITelephoneDomain
    {
        // Classe contendo a regra de negócio da Cliente
        protected readonly ITelephoneRepository _telephoneRepository;
        protected readonly IMapper _mapper;
        public TelephoneDomain(ITelephoneRepository telephoneRepository, IMapper mapper) 
        {
            _telephoneRepository = telephoneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TelephoneDto>> UpdateAsync(IEnumerable<TelephoneDto> telephones, int idClient)
        {
            var entity = _mapper.Map<IEnumerable<Telephone>>(telephones);
            var response = await _telephoneRepository.UpdateAsync(entity, idClient);
            return _mapper.Map<IEnumerable<TelephoneDto>>(response);
        }
    }
}
