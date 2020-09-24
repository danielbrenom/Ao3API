using Microsoft.AspNetCore.Mvc;

namespace Ao3Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult("Hello");
        }
    }
}