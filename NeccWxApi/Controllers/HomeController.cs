using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        /// <summary>
        /// 获得用户IP
        /// </summary>
        /// <returns>IP</returns>
        [EnableCors("CorsSample")]
        [HttpGet("IP")]
        public string GetUserIP()
        {
            var ip = Server.GetUserIp(Request.HttpContext);

            return "Your IP:" + ip;
        }
    }
}