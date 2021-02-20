using GenericApi.Model;
using GenericApi.Service.Services;
using GenericAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly EntityService _service;

        public EntityController(GenericApiContext dbContext)
        {
            _service = new EntityService(dbContext);
        }

        [HttpPost]
        public async Task<ActionResult<ResultDto<object>>> Get([FromBody]QueryDto query)
        {
            var data = await _service.GetData(query);

            return Ok(data);
        }

    }
}
