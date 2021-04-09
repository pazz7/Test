using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public abstract class BaseController : ControllerBase
    {
    }
}
