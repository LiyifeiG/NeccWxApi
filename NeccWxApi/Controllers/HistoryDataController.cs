using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class HistoryDataController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// Gets the profession list.
        /// </summary>
        /// <returns>The profession list.</returns>
        [HttpGet("ProfessionList&lp={localProvince}")]
        public IEnumerable<object> GetProfessionList(string localProvince)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[获得专业列表]");
                var re = HistoryDataServer.GetProfessionList(localProvince);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// Get the university list.
        /// </summary>
        /// <param name="localProvince">学生归属地</param>
        /// <returns>The university list.</returns>
        [HttpGet("UniversityList&lp={localProvince}")]
        public IEnumerable<object> GetUniversityList(string localProvince)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[获得学校列表]");
                var re = HistoryDataServer.GetUniversityList(localProvince);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// Query Profession
        /// </summary>
        /// <param name="localProvince">localProvince</param>
        /// <param name="year">year</param>
        /// <param name="classes">classes</param>
        /// <param name="lscore">lscore</param>
        /// <param name="rscore">range</param>
        /// <param name="proName">proName</param>
        /// <returns>ProfessionList</returns>
        [HttpGet("QueryProfession&lp={localProvince}&y={year}&c={classes}&ls={lscore}&rs={rscore}&proName={proName}")]
        public IEnumerable<object> QueryProfession(string localProvince , int year , string classes , int lscore , int rscore , string proName)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业列表]");
                var re = HistoryDataServer.QueryProfession(localProvince , year, classes, lscore, rscore, proName);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// Query University
        /// </summary>
        /// <param name="localProvince">localProvince</param>
        /// <param name="classes">classes</param>
        /// <param name="uniName">university name</param>
        /// <returns>univeristy list</returns>
        [HttpGet("QueryUniversity&lp={localProvince}&c={classes}&uniName={uniName}")]
        public IEnumerable<object> QueryUniversity(string localProvince, string classes, string uniName)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询学校列表]");
                var re = HistoryDataServer.QueryUniversity(localProvince , classes, uniName);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// Query Score
        /// </summary>
        /// <param name="localProvince">local province</param>
        /// <param name="year">year</param>
        /// <param name="classes">classes</param>
        /// <param name="lscore">lscore</param>
        /// <param name="rscore">rscore</param>
        /// <returns>univerisity list</returns>
        [HttpGet("QueryScore&lp={localProvince}&y={year}&c={classes}&ls={lscore}&rs={rscore}")]
        public IEnumerable<object> QueryScore(string localProvince, int year, string classes, int lscore, int rscore)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询分数列表]");
                var re = HistoryDataServer.QueryScore(localProvince, year, classes, lscore, rscore);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 学校开设专业列表
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="uniName">学校名称</param>
        /// <returns>专业列表</returns>
        [HttpGet("ProfessionListByUniversity&lp={localProvince}&uniName={uniName}")]
        public IEnumerable<object> ProfessionListByUniversity(string localProvince, string uniName)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[学校开设专业列表]");
                var re = HistoryDataServer.ProfessionListByUniversity(localProvince, uniName);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 查询开设了某专业的学校
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="uniName">专业名称</param>
        /// <returns>学校列表</returns>
        [HttpGet("UniversityListByProfession&lp={localProvince}&proName={proName}")]
        public IEnumerable<object> UniversityListByProfession(string localProvince, string proName)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[开设某专业学校列表]");
                var re = HistoryDataServer.UniversityListByProfession(localProvince, proName);
                DBLink.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }
    }
}
