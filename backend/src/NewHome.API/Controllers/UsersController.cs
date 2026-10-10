using Microsoft.AspNetCore.Mvc;
using NewHome.Domain.Users; 

namespace NewHome.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
      [HttpGet]

      public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]

        public IActionResult Post(User userId)
        {
            return Ok();
        }
    }
}
