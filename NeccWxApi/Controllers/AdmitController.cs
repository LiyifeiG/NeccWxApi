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
        [HttpGet("ProfessionList")]
        public IEnumerable<string> GetProfessionList()
        {
            var addr = Request.HttpContext.Connection.RemoteIpAddress;
            DBLink.Log("用户" + addr.MapToIPv4() + "接入接口[查询专业列表]");
            var re = AdmitServer.GetProfessionList();
            DBLink.Log("用户" + addr.MapToIPv4() + "退出");
            return re;
        }

        [HttpGet("UniversityList")]
        public IEnumerable<string> GetUniversityList()
        {
            return AdmitServer.GetUniversityList();
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
