using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NeccWxApi.Servers;

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
        ///
        [EnableCors("CorsSample")]
        [HttpGet("GetUniversity&uniName={uniName}")]
        public object GetUniversity(string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UniversityServer.GetUniversity(uniName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得985大学列表
        /// </summary>
        /// <returns>985大学列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("Get985UniversityList")]
        public IEnumerable<object> Get985UniversityList()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UniversityServer.Get985UniversityList();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得211大学列表
        /// </summary>
        /// <returns>211大学列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("Get211UniversityList")]
        public IEnumerable<object> Get211UniversityList()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UniversityServer.Get211UniversityList();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 判断学校属于985|211
        /// </summary>
        /// <returns>((985,211)|985|211|000)</returns>
        [EnableCors("CorsSample")]
        [HttpGet("UniversityIs985Or211&uniName={uniName}")]
        public object UniversityIs985Or211(string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UniversityServer.UniversityIs985Or211(uniName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得前N个学校信息列表
        /// </summary>
        /// <param name="listCount">学校个数</param>
        /// <returns>学校列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetUniversityList&c={listCount}")]
        public IEnumerable<object> GetUniversityList(int listCount)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = UniversityServer.GetUniversityList(listCount);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

    }
}
