using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NeccWxApi;


public class AdmitServer
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

    /// <summary>
    /// get university detail information
    /// </summary>
    /// <returns>the university detail information</returns>
    public static object GetUniversityInformation(string uniName)
    {
        DBLink.Log("开始连接");
        var con = DBLink.Connect();
        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");
            return null;
        }

        var sqlStr = "SELECT uniID , uniName , address , type , subject , eduBackg , residing , webSite " +
                              "FROM University WHERE uniName = '" + uniName + "'";

        var sc = new SqlCommand(sqlStr , con);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        if (reader.Read())
        {
            return new
            {
                院校ID = (int)reader[0] ,
                院校名称 = (string)reader[1],
                院校地点 = (string)reader[2],
                办学类型 = (string)reader[3],
                院校类型 = (string)reader[4],
                办学层次 = (string)reader[5],
                院校隶属 = (string)reader[6],
                院校官网 = (string)reader[7]
            };
        }

        DBLink.DisConnect(con);

        DBLink.Log("连接关闭");

        return null;
    }

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