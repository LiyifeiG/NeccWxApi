using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Models;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class NewHistoryDataQueryController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }


        /// <summary>
        /// 精确查询
        /// </summary>
        /// <param name="qunpm">查询参数</param>
        /// <param name="localProvince">生源地</param>
        /// <returns></returns>
        [HttpPost("QueryUniversity&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryUniversity([FromBody]QUniNameParModel qunpm , string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.QueryUniversity(qunpm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 精确查询专业
        /// </summary>
        /// <param name="qpnpm">查询参数</param>
        /// <param name="localProvince">生源地</param>
        /// <returns>查询结果</returns>
        [HttpPost("QueryProfession&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryProfession([FromBody] QProNameParModel qpnpm, string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.QueryProfession(qpnpm , localProvince);

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
        /// <param name="qspm">查询参数头</param>
        /// <param name="localProvince">生源地</param>
        /// <returns>查询结果</returns>
        [HttpPost("QueryScore&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryScore([FromBody] QScoreParModel qspm, string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.QueryScore(qspm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }


        /// <summary>
        /// 所有的院校所在地
        /// </summary>
        /// <returns>所有的院校所在地</returns>
        [HttpGet("AllUniLocal")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniLocal()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.AllUniLocal();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 所有的院校类型
        /// </summary>
        /// <returns>所有的院校类型</returns>
        [HttpGet("AllUniType")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniType()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.AllUniType();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 所有的批次
        /// </summary>
        /// <returns>所有的批次</returns>
        [HttpGet("AllUniBatch")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniBatch()
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = NewHistoryDataQueryServer.AllUniBatch();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}