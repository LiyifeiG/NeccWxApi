using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace NeccWxApi
{
    public class Server
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
            {"河南" , "Yu"} , {"陕西" , "Shan"}
        };

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            File.AppendAllText("log.txt" , DateTime.Now + " : " + msg + "\n");
        }
    }
}
