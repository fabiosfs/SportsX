using AutoMapper;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Services
{
    public class ClassificationDomain : IClassificationDomain
    {
        // Classe contendo a regra de negócio da Classificação
        protected readonly IClassificationRepository _classificationRepository;
        protected readonly IMapper _mapper;
        public ClassificationDomain(IClassificationRepository classificationRepository, IMapper mapper) 
        {
            _classificationRepository = classificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassificationDto>> GetAllAsync()
        {
            var response = await _classificationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassificationDto>>(response);
        }

        public async Task<ClassificationDto> GetByIdAsync(int id)
        {
            var response = await _classificationRepository.GetByIdAsync(id);
            return _mapper.Map<ClassificationDto>(response);
        }
    }
}
