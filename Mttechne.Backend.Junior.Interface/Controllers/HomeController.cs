using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mttechne.Backend.Junior.Interface.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]

    //HealthCheck vai verificar se o servidor está respondendo
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Home()
        {
            return Redirect($"{Request.Scheme}://{Request.Host.ToUriComponent()}/swagger");
        }

        [HttpGet("health-check")]
        public IActionResult HealthCheck()
        {
            var response = new { Environment.MachineName };
            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}
