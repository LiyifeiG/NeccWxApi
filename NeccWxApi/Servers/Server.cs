using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace NeccWxApi
{
    public static class Server
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string SqlConString = "";

        /// <summary>
        /// 生源地与数据库对照字典
        /// </summary>
        public static Dictionary<string, string> Province = new Dictionary<string, string>()
        {
            {"河南", "Yu"},
            {"陕西", "Shan"}
        };

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            File.AppendAllText("log.txt", DateTime.Now + " : " + msg + "\n");
        }

        /// <summary>
        /// 获得用户ID
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUserIp(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }

            return ip;
        }


        /// <summary>
        /// 对用户IP进行处理
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static int IPHandle(string ip)
        {
            using (var con = new SqlConnection(SqlConString))
            {

                con.Open();

                var str = "SELECT availableTimes FROM UserIP WHERE address = '" + ip + "'";

                var result = new SqlCommand(str, con).ExecuteReader();

                if (result.Read())
                {
                    var times = (int)result[0];

                    if (times == 0)
                        return 0;
                    if (times == -1)
                        return -1;

                    var availableTimes = times - 1;

                    str = "UPDATE UserIP SET availableTimes = " + availableTimes +
                          " WHERE address = '" + ip + "'";

                    new SqlCommand(str, con).ExecuteNonQuery();

                    return times;
                }
                str = "INSERT INTO UserIP (address) values ( ( '" + ip + "' ) );";

                new SqlCommand(str, con).ExecuteNonQuery();


                return 500;
            }
        }

    }
}
