using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NeccWxApi;


public class HistoryDataServer
{
    /// <summary>
    /// Gets the profession list.
    /// </summary>
    /// <returns>The profession list.</returns>
	public static List<object> GetProfessionList(string localProvince)
    {
        DBLink.Log("开始连接");

        var con = DBLink.Connect();

        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");

            return null;
        }

        var re = new List<object>();


        var sqlStr = "SELECT DISTINCT proID , proName FROM " + DBLink.Province[localProvince] + "Admit  ORDER BY proName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
              re.Add(new
              {
                  专业ID = reader[0] == DBNull.Value ? "错误数据" : (string)reader[0],
                  专业名称 = (string)reader[1]
              });

        }

        DBLink.Log("获得结果 " + re.Count + "条");

        DBLink.DisConnect(con);

        DBLink.Log("连接关闭");

        return re;
    }

    /// <summary>
    /// Gets the university list
    /// </summary>
    /// <returns>the university list</returns>
    public static List<object> GetUniversityList(string localProvince)
    {
        DBLink.Log("开始连接");
        var con = DBLink.Connect();
        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");
            return null;
        }

        var re = new List<object>();

        var sqlStr = "SELECT DISTINCT uniID , uniName FROM "+ DBLink.Province[localProvince] + "Admit ORDER BY uniName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
            re.Add(new
            {
                院校ID = (int)reader[0] ,
                院校名称 = (string)reader[1]
            });
        }

        DBLink.Log("获得结果 " + re.Count + "条");

        DBLink.DisConnect(con);

        DBLink.Log("连接关闭");

        return re;
    }



}