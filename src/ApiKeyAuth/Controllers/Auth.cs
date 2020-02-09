using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web;
namespace TestAPISecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public ActionResult<HttpResponseMessage> Forbidden()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.Forbidden) 
            {
                ReasonPhrase = ApiKeyAuth.GlobalSettings.NoApiKeyReasonPhrase
            };
            return new ActionResult<HttpResponseMessage>(msg);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<HttpResponseMessage> NotAuthorized()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) 
            {
                ReasonPhrase = ApiKeyAuth.GlobalSettings.NotAuthorizedReasonPhrase
            };
            return new ActionResult<HttpResponseMessage>(msg);
        }
    }
}
