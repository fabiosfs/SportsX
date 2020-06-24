using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTypeController : ControllerBase
    {
        private IClientTypeDomain _clientTypeDomain {get;set;}
        public ClientTypeController(IClientTypeDomain clientTypeDomain)
        {
            _clientTypeDomain = clientTypeDomain;
        }

        // GET: api/ClientType
        [HttpGet]
        public async Task<IEnumerable<ClientTypeDto>> Get()
        {
            var returned = await _clientTypeDomain.GetAllAsync();
            return returned;
        }

        // GET: api/ClientType/5
        [HttpGet("{id}")]
        public async Task<ClientTypeDto> Get(int id)
        {
            var returned = await _clientTypeDomain.GetByIdAsync(id);
            return returned;
        }
    }
}
