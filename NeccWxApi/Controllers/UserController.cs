using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Models;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [EnableCors("CorsSample")]
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录结果</returns>
        [EnableCors("CorsSample")]
        [HttpGet("Login&a={account}&p={password}")]
        public object Login(string account, string password)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[登录]");
                var re = UserServer.Login(account, password);
                Server.Log("用户" + addr + "退出");
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="active">秘钥</param>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="phoneNum">电话</param>
        /// <returns>注册结果</returns>
        [HttpGet("Register&c={active}&a={account}&p={password}&n={phoneNum}")]
        [EnableCors("CorsSample")]
        public object Register(string active, string account, string password, string phoneNum)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[注册]");
                if (UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return new { msg = "账号已存在" };
                }

                if (UserServer.ActiveCodeState(active).Equals("秘钥不可用")
                    || UserServer.ActiveCodeState(active).Equals("秘钥不存在"))
                {
                    return new { msg = "秘钥不存在或者不可用" };
                }

                var re = UserServer.Register(active, account, password, phoneNum);
                Server.Log("用户" + addr + "退出");
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">请求正文</param>
        /// <returns>结果</returns>
        [HttpPut("pRegister")]
        [EnableCors("CorsSample")]
        public object Register([FromBody] User user)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[注册]");

                if (user == null)
                {
                    return new { msg = "无效put请求" };
                }

                var account = user.Account;
                var active = user.ActiveCode;
                var password = user.Password;
                var phoneNum = user.PhoneNum;

                if (UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return new { msg = "账号已存在" };
                }

                if (UserServer.ActiveCodeState(active).Equals("秘钥不可用")
                    || UserServer.ActiveCodeState(active).Equals("秘钥不存在"))
                {
                    return new { msg = "秘钥不存在或者不可用" };
                }

                var re = UserServer.Register(active, account, password, phoneNum);
                Server.Log("用户" + addr + "退出");
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>结果</returns>
        [HttpGet("AccountIsExist&a={account}")]
        [EnableCors("CorsSample")]
        public object AccountIsExist(string account)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[判断账号存在]");
                var re = UserServer.AccountIsExist(account);
                Server.Log("用户" + addr + "退出");
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 判断秘钥状态
        /// </summary>
        /// <param name="activeCode">秘钥</param>
        /// <returns>结果</returns>
        [HttpGet("ActiveCodeState&a={activeCode}")]
        [EnableCors("CorsSample")]
        public object ActiveCodeState(string activeCode)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                Server.Log("用户" + addr + "接入接口[判断秘钥状态]");
                var re = UserServer.ActiveCodeState(activeCode);
                Server.Log("用户" + addr + "退出");
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="newPassword">密码</param>
        /// <returns>修改结果</returns>
        [HttpGet("ModifyPassword&a={account}&np={newPassword}")]
        [EnableCors("CorsSample")]
        public object ModifyPassowrd(string account, string newPassword)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new
                    {
                        msg = "本IP测试次数已达上限"
                    };
                }
                if (!UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return new
                    {
                        msg = "账号不存在"
                    };
                }
                Server.Log("用户" + addr + "接入接口[修改密码]");
                var re = UserServer.ModifyPassowrd(account, newPassword);
                Server.Log("用户" + addr + "退出");
                return new
                {
                    msg = re
                };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user">请求体</param>
        /// <returns>结果</returns>
        [HttpPost("pModifyPassword")]
        [EnableCors("CorsSample")]
        public object ModifyPassword([FromBody] User user)
        {
            try
            {

                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new
                    {
                        msg = "本IP测试次数已达上限"
                    };
                }

                if (user == null)
                {
                    return new { msg = "请求错误" };
                }

                var account = user.Account;
                var newPassword = user.Password;

                if (!UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return new
                    {
                        msg = "账号不存在"
                    };
                }
                Server.Log("用户" + addr + "接入接口[修改密码]");
                var re = UserServer.ModifyPassowrd(account, newPassword);
                Server.Log("用户" + addr + "退出");
                return new
                {
                    msg = re
                };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }


        }

        /// <summary>
        /// 查看用户信息
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>用户信息</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetUser&a={account}")]
        public object GetUser(string account)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new { msg = "本IP测试次数已达上限" };
                }
                if (!UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return new { msg = "账号不存在" };
                }
                Server.Log("用户" + addr + "接入接口[查看用户]");
                var re = UserServer.GetUser(account);
                Server.Log("用户" + addr + "退出");
                return re;
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }
    }
}
