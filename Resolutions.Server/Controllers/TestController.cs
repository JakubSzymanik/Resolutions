using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Resolutions.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet] 
        public ActionResult<string> GetTestAuthorized()
        {
            return Ok("Success");
        }

        [HttpGet]
        public ActionResult<string> GetTestNonAuthorized()
        {
            return Ok("Success");
        }
    }
}
