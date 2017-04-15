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
        /// 全部专业列表
        /// </summary>
        // <param name="localProvince">生源地</param>
        /// <returns>专业列表</returns>
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
        /// 全部院校列表
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <returns>学校列表</returns>
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
        /// 专业查询
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="year">年份</param>
        /// <param name="classes">类别</param>
        /// <param name="lscore">分数下限</param>
        /// <param name="rscore">分数上限</param>
        /// <param name="proName">专业名称</param>
        /// <returns>专业列表</returns>
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
        /// 院校查询
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="classes">类别</param>
        /// <param name="uniName">院校名称</param>
        /// <returns>院校列表</returns>
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
        /// 分数查询
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="year">年份</param>
        /// <param name="classes">类别</param>
        /// <param name="lscore">分数下限</param>
        /// <param name="rscore">分数上限</param>
        /// <returns>学校列表</returns>
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
