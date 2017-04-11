using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class UniversityController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "API University连接正常,可以使用";
        }

        /// <summary>
        /// Get the university detail information.
        /// </summary>
        /// <param name="uniName">学校名称</param>
        /// <returns>The university detail information.</returns>
        [HttpGet("GetUniversity&uniName={uniName}")]
        public object GetUniversity(string uniName)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询学校具体信息]");
            var re = UniversityServer.GetUniversity(uniName);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }

    }
}
