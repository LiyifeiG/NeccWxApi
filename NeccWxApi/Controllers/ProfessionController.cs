using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfessionController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "API Profession连接正常,可以使用";
        }

        /// <summary>
        /// get profession detail information
        /// </summary>
        /// <returns>the profession detail information</returns>
        [HttpGet("GetProfession&proName={proName}")]
        public object GetProfession(string proName)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业具体信息]");
            var re = ProfessionServer.GetProfessionInformation(proName);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }
    }
}
