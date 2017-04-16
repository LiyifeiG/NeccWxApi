using System.Threading.Tasks;
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

        /// <summary>
        /// 获得用户IP
        /// </summary>
        /// <returns>IP</returns>
        [HttpGet("IP")]
        public string GetUserIP()
        {
            var ip = Server.GetUserIp(Request.HttpContext);

            var times = Server.IPHandle(ip);

            return ip + " : " + times;
        }
    }
}