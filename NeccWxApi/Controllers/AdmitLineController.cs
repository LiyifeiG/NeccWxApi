﻿using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 获得分数线API
    /// </summary>
    [Route("api/[controller]")]
    public class AdmitLineController : Controller
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
        /// 获得分数线信息
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <returns>分数线</returns>
        [HttpGet("GetAllAdmitLine&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public object GetAllAdmitLine(string localProvince)
        {           
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = AdmitLineServer.GetAllAdmitLine(localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}
