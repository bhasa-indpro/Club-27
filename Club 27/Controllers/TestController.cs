using Microsoft.AspNetCore.Mvc;

namespace Club_27.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public String Bhasa()
        {
            return "hi";
        }
    }
}
