using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private IClassificationDomain _classificationDomain { get;set;}
        public ClassificationController(IClassificationDomain classificationDomain)
        {
            _classificationDomain = classificationDomain;
        }

        // GET: api/Classification
        [HttpGet]
        public async Task<IEnumerable<ClassificationDto>> Get()
        {
            var returned = await _classificationDomain.GetAllAsync();
            return returned;
        }

        // GET: api/Classification/5
        [HttpGet("{id}")]
        public async Task<ClassificationDto> Get(int id)
        {
            var returned = await _classificationDomain.GetByIdAsync(id);
            return returned;
        }
    }
}
