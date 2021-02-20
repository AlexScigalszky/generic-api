using GenericApi.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GenericAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] string entity)
        {
            return new PropertiesService().GetPropertiesOf(entity);
        }
    }
}
