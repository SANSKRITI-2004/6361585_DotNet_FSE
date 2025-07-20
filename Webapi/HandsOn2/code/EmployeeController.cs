using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/emp")]

    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "John", "Jane", "David" };
        }
    }
}
