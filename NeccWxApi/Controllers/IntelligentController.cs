using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Models;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 智能查询API
    /// </summary>
    [Route("api/[controller]")]
    public class IntelligentController : Controller
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
        /// 智能推荐
        /// </summary>
        /// <returns>推荐的学校列表</returns>
        /// <param name="score">分数</param>
        /// <param name="pnum">位次</param>
        /// <param name="localProvince">省份</param>
        /// <param name="classes">科类</param>
        /// <param name="year">年份</param>
        [HttpGet("IntelligentRecommendation&lp={localProvince}&s={score}&p={pnum}&c={classes}&y={year}")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> IntelligentRecommendation(decimal score , int pnum , string localProvince , string classes , int year)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = IntelligentServer.IntelligentRecommendation(score , pnum , localProvince , classes , year );

                return re;
            }
            catch (System.Exception ex)
            {
                return new[] { new { msg =  ex.Message} };
            }
        }
//        [HttpGet("IntelligentRecommendation&lp={localProvince}")]
//        [EnableCors("CorsSample")]
//        public IEnumerable<object> IntelligentRecommendation([FromBody] IntelligentModel im, string localProvince)
//        {
//            try
//            {
//                var addr = Server.GetUserIp(Request.HttpContext);
//                if (Server.IPHandle(addr) == 0)
//                {
//                    return new[] { "your ip can't using our api , please contact administrator" };
//                }
//
//                var re = IntelligentServer.IntelligentRecommendation(im , localProvince);
//
//                return re;
//            }
//            catch (System.Exception ex)
//            {
//                return new[] { new { msg =  ex.Message} };
//            }
//        }
    }
}
