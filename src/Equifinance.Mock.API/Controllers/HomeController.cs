using Microsoft.AspNetCore.Mvc;

namespace Equifinance.Mock.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index() => "Welcome to my API!";
    }
}
