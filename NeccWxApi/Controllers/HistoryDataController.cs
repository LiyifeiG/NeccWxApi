using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 历史数据API
    /// </summary>
    [Route("api/[controller]")]
    public class HistoryDataController : Controller
    {
        /// <summary>
        /// 界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 全部专业列表
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <returns>专业列表</returns>
        [HttpGet("ProfessionList&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> GetProfessionList(string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.GetProfessionList(localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 全部院校列表
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <returns>学校列表</returns>
        [HttpGet("UniversityList&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> GetUniversityList(string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.GetUniversityList(localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
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
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryProfession(string localProvince, int year, string classes, int lscore, int rscore, string proName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.QueryProfession(localProvince, year, classes, lscore, rscore, proName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
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
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryUniversity(string localProvince, string classes, string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.QueryUniversity(localProvince, classes, uniName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
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
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryScore(string localProvince, int year, string classes, int lscore, int rscore)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.QueryScore(localProvince, year, classes, lscore, rscore);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 学校开设专业列表
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="uniName">学校名称</param>
        /// <returns>专业列表</returns>
        [HttpGet("ProfessionListByUniversity&lp={localProvince}&uniName={uniName}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> ProfessionListByUniversity(string localProvince, string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.ProfessionListByUniversity(localProvince, uniName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 查询开设了某专业的学校
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="proName">专业名称</param>
        /// <returns>学校列表</returns>
        [HttpGet("UniversityListByProfession&lp={localProvince}&proName={proName}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> UniversityListByProfession(string localProvince, string proName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.UniversityListByProfession(localProvince, proName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 获得学校的具体专业信息
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="uniName">学校名</param>
        /// <returns></returns>
        [HttpGet("ProfessionListByDetailUniversity&lp={localProvince}&uniName={uniName}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> ProfessionListByDetailUniversity(string localProvince,string uniName)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = HistoryDataServer.ProfessionListByDetailUniversity(localProvince,uniName);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}
