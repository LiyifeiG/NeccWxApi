using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class AdmitController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Admit连接正常";
        }

        /// <summary>
        /// Gets the profession list.
        /// </summary>
        /// <returns>The profession list.</returns>
        [HttpGet("ProfessionList&lp={localProvince}")]
        public IEnumerable<Tuple<string , string>> GetProfessionList(string localProvince)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业列表]");
            var re = AdmitServer.GetProfessionList(localProvince);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }

        [HttpGet("UniversityList&lp={localProvince}")]
        public IEnumerable<Tuple<string , string>> GetUniversityList(string localProvince)
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询学校列表]");
            var re = AdmitServer.GetUniversityList(localProvince);
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
