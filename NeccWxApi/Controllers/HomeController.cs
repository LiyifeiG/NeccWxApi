using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }
    }
}