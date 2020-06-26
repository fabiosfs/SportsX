using Microsoft.AspNetCore.Mvc;
using SportsX.Domain.Dto;
using SportsX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private ITelephoneDomain _TelephoneDomain { get;set;}
        public TelephoneController(ITelephoneDomain TelephoneDomain)
        {
            _TelephoneDomain = TelephoneDomain;
        }

        // PUT: api/telephone/client/5
        [HttpPut("client/{id}")]
        public async Task<IEnumerable<TelephoneDto>> Put([FromBody] IEnumerable<TelephoneDto> telephones, int id)
        {
            var returned = await _TelephoneDomain.UpdateAsync(telephones, id);
            return returned;
        }
    }
}
