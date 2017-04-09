﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace NeccWxApi
{
    public class DBLink
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
        /// 打开数据库通道
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Connect()
        {
            Log("准备连接，连接字符串为 : " + SqlConString);
            var SqlConnection = new SqlConnection
            {
                ConnectionString = SqlConString
            };
            try
            {
                SqlConnection.Open();

                if (SqlConnection.State == ConnectionState.Open)
                {
                    Log("连接正常");
                    return SqlConnection;
                }
            }
            catch (Exception e)
            {
                Log( "连接异常 : " + e.Message);
                return null;
            }

            return null;
        }

        /// <summary>
        /// 关闭数据库通道
        /// </summary>
        /// <returns></returns>
        public static bool DisConnect(SqlConnection sqsc)
        {
            if (sqsc.State == ConnectionState.Closed)
            {
                return true;
            }
            try
            {
                sqsc.Close();
            }
            catch (Exception e)
            {
                Log("断开异常 : " + e.Message);
            }
            return sqsc.State == ConnectionState.Closed;
        }

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
