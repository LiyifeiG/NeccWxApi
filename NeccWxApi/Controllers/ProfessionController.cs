using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [EnableCors("CorsSample")]
        [HttpGet("GetProfession&proName={proName}")]
        public object GetProfession(string proName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[查询专业具体信息]");
                var re = ProfessionServer.GetProfession(proName);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得一等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfessionFieldList&fieldName={fieldName}")]
        public IEnumerable<object> GetProfessionFieldList(string fieldName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[获得一等科类专业列表]");
                var re = ProfessionServer.GetProfessionFieldList(fieldName);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
        /// <summary>
        /// 获得二等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfessionDisciplineList&disName={disName}")]
        public IEnumerable<object> GetProfessionDisciplineList(string disName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[获得二等科类专业列表]");
                var re = ProfessionServer.GetProfessionDisciplineList(disName);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得一等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("FieldList")]
        public IEnumerable<object> FieldList()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[获得二等科类列表]");
                var re = ProfessionServer.FieldList();
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
        /// <summary>
        /// 获得二等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("DisciplineList")]
        public IEnumerable<object> DisciplineList()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[获得二等科类列表]");
                var re = ProfessionServer.DisciplineList();
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
