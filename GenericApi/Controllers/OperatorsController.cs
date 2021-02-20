using GenericApi.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GenericAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new OperatorServices().GetErrorList();
        }
    }
}
