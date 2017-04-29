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
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = ProfessionServer.GetProfession(proName);

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
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = ProfessionServer.GetProfessionFieldList(fieldName);

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
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = ProfessionServer.GetProfessionDisciplineList(disName);

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
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = ProfessionServer.FieldList();

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
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = ProfessionServer.DisciplineList();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}
