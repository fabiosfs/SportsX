using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientDomain _clientDomain { get;set;}
        public ClientController(IClientDomain clientDomain)
        {
            _clientDomain = clientDomain;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<IEnumerable<ClientDto>> Get()
        {
            var returned = await _clientDomain.GetAllAsync();
            return returned;
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ClientDto> Get(int id)
        {
            var returned = await _clientDomain.GetByIdAsync(id);
            return returned;
        }
    }
}
