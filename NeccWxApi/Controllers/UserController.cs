using System;
using Microsoft.AspNetCore.Mvc;

namespace NeccWxApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录结果</returns>
        [HttpGet("Login&lp={localProvince}&a={account}&p={password}")]
        public string Login(string localProvince, string account, string password)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[登录]");
                var re = UserServer.Login(localProvince, account, password);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
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
        public string Register(string active, string account, string password, string phoneNum)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[注册]");
                if (UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return "账号已存在";
                }

                if (UserServer.ActiveCodeState(active).Equals("秘钥不可用")
                    || UserServer.ActiveCodeState(active).Equals("秘钥不存在"))
                {
                    return "秘钥不存在或者不可用";
                }

                var re = UserServer.Register(active, account, password, phoneNum);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>结果</returns>
        [HttpGet("AccountIsExist&a={account}")]
        public string AccountIsExist(string account)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[判断账号存在]");
                var re = UserServer.AccountIsExist(account);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 判断秘钥状态
        /// </summary>
        /// <param name="activeCode">秘钥</param>
        /// <returns>结果</returns>
        [HttpGet("ActiveCodeState&a={activeCode}")]
        public string ActiveCodeState(string activeCode)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[判断秘钥状态]");
                var re = UserServer.ActiveCodeState(activeCode);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="newPassword">密码</param>
        /// <returns>修改结果</returns>
        [HttpGet("ModifyPassword&a={account}&np={newPassword}")]
        public string ModifyPassowrd(string account, string newPassword)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                if (!UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return "账号不存在";
                }
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[修改密码]");
                var re = UserServer.ModifyPassowrd(account, newPassword);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 查看用户信息
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>用户信息</returns>
        [HttpGet("GetUser&a={account}")]
        public object GetUser(string account)
        {
            try
            {
                var addr = Request.HttpContext.Connection.RemoteIpAddress;
                if (!UserServer.AccountIsExist(account).Equals("已存在"))
                {
                    return "账号不存在";
                }
                Server.Log("用户" + addr.MapToIPv4() + "接入接口[查看用户]");
                var re = UserServer.GetUser(account);
                Server.Log("用户" + addr.MapToIPv4() + "退出");
                return re;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
