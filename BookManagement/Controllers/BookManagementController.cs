using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookManagementController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}