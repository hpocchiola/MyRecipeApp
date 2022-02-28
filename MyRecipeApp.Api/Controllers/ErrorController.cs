using Microsoft.AspNetCore.Mvc;

namespace MyRecipeApp.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
