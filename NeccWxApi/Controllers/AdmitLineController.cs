using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace NeccWxApi
{
    [Route("api/[controller]")]
    public class AdmitLineController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        [HttpGet("GetAllAdmitLine&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public object GetAllAdmitLine(string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[获得专业列表]");
                var re = AdmitLineServer.GetAllAdmitLine(localProvince);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}
