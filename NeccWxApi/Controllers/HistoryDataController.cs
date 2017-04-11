using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class HistoryDataController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "API HistoryData连接正常,可以使用";
        }

        /// <summary>
        /// Gets the profession list.
        /// </summary>
        /// <returns>The profession list.</returns>
        [HttpGet("ProfessionList&lp={localProvince}")]
        public IEnumerable<object> GetProfessionList(string localProvince)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业列表]");
            var re = HistoryDataServer.GetProfessionList(localProvince);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }

        /// <summary>
        /// Get the university list.
        /// </summary>
        /// <param name="localProvince">学生归属地</param>
        /// <returns>The university list.</returns>
        [HttpGet("UniversityList&lp={localProvince}")]
        public IEnumerable<object> GetUniversityList(string localProvince)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询学校列表]");
            var re = HistoryDataServer.GetUniversityList(localProvince);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }
    }
}
