using System;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfessionController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 查询专业信息
        /// </summary>
        /// <returns>专业信息</returns>
        [HttpGet("GetProfession&proName={proName}")]
        public object GetProfession(string proName)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业具体信息]");
                var re = ProfessionServer.GetProfession(proName);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }
    }
}
