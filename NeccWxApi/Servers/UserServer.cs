using System.Data.SqlClient;

namespace NeccWxApi.Servers
{
    public static class UserServer
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录结果</returns>
        public static string Login(string account, string password)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                string re;

                var sqlStr = "SELECT password FROM UserAccount " +
                             "WHERE account = '" + account + "'";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                if (reader.Read())
                {
                    re = ((string)reader[0]).Equals(password) ? "login successful" : "wrong password";
                }
                else
                {
                    re = "account not found";
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
        public static object Register(string active, string account, string password, string phoneNum)
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

                var re = i == 1 ? "registration successful" : "registration failed";

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
                var re = reader.Read() ? "account is exists" : "account is not exists";

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
                    if ((bool)reader[0])
                    {
                        re = "key is available";
                    }
                    else
                    {
                        re = "key is invalid";
                    }
                }
                else
                {
                    re = "key is not found";
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

                var re = i == 1 ? "successful" : "faild";

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
                        account = (string)reader[0],
                        password = (string)reader[1],
                        phoneNumber = (string)reader[2],
                        province = (string)reader[3],
                        userType = (string)reader[4]
                    };
                }
                else
                {
                    re = "key is not found";
                }

                return re;
            }
        }
    }
}