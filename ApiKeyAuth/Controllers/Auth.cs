using Microsoft.AspNetCore.Mvc;

namespace TestAPISecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public ActionResult NotAuthorized()
        {
            return NotFound();
        }
}
}
