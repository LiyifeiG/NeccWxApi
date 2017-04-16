using System;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class UniversityController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 查询院校信息
        /// </summary>
        /// <param name="uniName">学校名称</param>
        /// <returns>院校信息</returns>
        [HttpGet("GetUniversity&uniName={uniName}")]
        public object GetUniversity(string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] {"本IP测试次数已达上限"};
                }
                Server.Log("用户" + addr + "接入接口[查询学校具体信息]");
                var re = UniversityServer.GetUniversity(uniName);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }
    }
}
