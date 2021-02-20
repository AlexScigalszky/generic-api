using GenericApi.Model;
using GenericApi.Service.Services;
using GenericAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace GenericAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private EntityService _service;

        public EntityController(GenericApiContext dbContext)
        {
            _service = new EntityService(dbContext);
        }

        [Route("[action]")]
        [HttpPost]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ResultDto<object>))]
        public async Task<ActionResult<ResultDto<object>>> Get([FromBody]QueryDto query)
        {
            var data = await _service.GetData(query);

            return Ok(data);
        }

    }
}
