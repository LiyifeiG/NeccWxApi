using System.Data.SqlClient;

namespace NeccWxApi
{
    public class UserServer
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录结果</returns>
        public static string Login(string localProvince, string account, string password)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                string re;

                var sqlStr = "SELECT password FROM UserAccount " +
                             "WHERE account = '" + account + "' AND province = '" + localProvince + "' ";

                var sc = new SqlCommand(sqlStr, con);

                Server.Log("开始查询 : 语句为" + sqlStr);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                if (reader.Read())
                {
                    re = ((string) reader[0]).Equals(password) ? "登录成功" : "密码错误";
                }
                else
                {
                    re = "生源地或者账号错误";
                }

                return re;
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
        public static string Register(string active, string account, string password, string phoneNum)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr = "UPDATE UserAccount " +
                             "SET account = '" + account + "' , " +
                             "password = '" + password + "' , " +
                             "phoneNum = '" + phoneNum + "' , " +
                             "activeState = 0 " +
                             "WHERE active = '" + active + "' ";
                var sc = new SqlCommand(sqlStr, con);

                var i = sc.ExecuteNonQuery();

                var re = i == 1 ? "成功" : "失败";

                return re;
            }
        }


        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>结果</returns>
        public static string AccountIsExist(string account)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr = "SELECT account FROM UserAccount " +
                             "WHERE account = '" + account + "'";
                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();
                var reader = sc.ExecuteReader();
                var re = reader.Read() ? "已存在" : "不存在";

                return re;
            }
        }

        /// <summary>
        /// 判断秘钥状态
        /// </summary>
        /// <param name="activeCode">秘钥</param>
        /// <returns>结果</returns>
        public static string ActiveCodeState(string activeCode)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                string re;

                var sqlStr = "SELECT activeState FROM UserAccount " +
                             "WHERE active = '" + activeCode + "'";
                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();
                var reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    if ((bool) reader[0])
                    {
                        re = "秘钥可用";
                    }
                    else
                    {
                        re = "秘钥不可用";
                    }
                }
                else
                {
                    re = "秘钥不存在";
                }

                return re;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="newPassword">密码</param>
        /// <returns></returns>
        public static string ModifyPassowrd(string account, string newPassword)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr = "UPDATE UserAccount " +
                             "SET password = '" + newPassword + "' " +
                             "WHERE account = '" + account + "'";
                var sc = new SqlCommand(sqlStr, con);

                var i = sc.ExecuteNonQuery();

                var re = i == 1 ? "成功" : "失败";

                return re;
            }
        }

        /// <summary>
        /// 查看用户
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>用户信息</returns>
        public static object GetUser(string account)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                object re;

                var sqlStr = "SELECT account , password , phoneNum , province , userType FROM UserAccount " +
                             "WHERE account = '" + account + "'";
                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();
                var reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    re = new
                    {
                        账号 = (string) reader[0],
                        密码 = (string) reader[1],
                        电话 = (string) reader[2],
                        省份 = (string) reader[3],
                        用户类型 = (string) reader[4]
                    };
                }
                else
                {
                    re = "秘钥不存在";
                }

                return re;
            }
        }
    }
}