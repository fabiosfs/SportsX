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

        // POST: api/Client
        [HttpPost]
        public async Task<ClientDto> Post([FromBody] ClientDto client)
        {
            var returned = await _clientDomain.InsertAsync(client);
            return returned;
        }

        // PUT: api/Client
        [HttpPut]
        public async Task<ClientDto> Put([FromBody] ClientDto client)
        {
            var returned = await _clientDomain.UpdateAsync(client);
            return returned;
        }

        // Delete: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clientDomain.DeleteAsync(id);
            return Ok();
        }
    }
}
