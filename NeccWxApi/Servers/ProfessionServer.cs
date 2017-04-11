﻿using System.Data;
using System.Data.SqlClient;

namespace NeccWxApi
{
    public class ProfessionServer
    {

        /// <summary>
        /// get profession detail information
        /// </summary>
        /// <returns>the profession detail information</returns>
        public static object GetProfessionInformation(string proName)
        {
            DBLink.Log("开始连接");
            var con = DBLink.Connect();
            if (con.State != ConnectionState.Open)
            {
                DBLink.Log("连接未打开");
                return null;
            }

            var sqlStr =
                "SELECT proID , proName , proNameE , field , discipline , degree , mainCoursed , introduction FROM " +
                "Profession WHERE proName = '"+ proName + "'";

            var sc = new SqlCommand(sqlStr , con);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            if (reader.Read())
            {
                return new
                {
                    专业ID = (string)reader[0] ,
                    专业名称 = (string)reader[1],
                    英文名称 = (string)reader[2],
                    专业类型 = (string)reader[3],
                    院校具体类型 = (string)reader[4],
                    所授学位 = (string)reader[5],
                    主修课程 = (string)reader[6],
                    专业简介 = (string)reader[7]
                };
            }

            DBLink.DisConnect(con);

            DBLink.Log("连接关闭");

            return null;
        }
    }
}