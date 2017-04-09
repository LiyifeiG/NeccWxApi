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
	public static List<Tuple<string , string>> GetProfessionList(string localProvince)
    {
        DBLink.Log("开始连接");

        var con = DBLink.Connect();

        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");

            return null;
        }

        var re = new List<Tuple<string , string>>();

        const string sqlStr = "SELECT DISTINCT proID , proName FROM sf_score_admit ORDER BY sf_score_admit.proName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
            re.Add(new Tuple<string , string>( (int)reader[0] + ""  , (string)reader[1]));
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
    public static List<Tuple<string , string>> GetUniversityList(string localProvince)
    {
        DBLink.Log("开始连接");
        var con = DBLink.Connect();
        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");
            return null;
        }

        var re = new List<Tuple<string , string>>();

        const string sqlStr = "SELECT DISTINCT uniID , uniName FROM sf_score_admit ORDER BY sf_score_admit.uniName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
            re.Add(new Tuple<string , string>((int)reader[0] + "" , (string)reader[1]));
        }

        DBLink.Log("获得结果 " + re.Count + "条");

        DBLink.DisConnect(con);

        DBLink.Log("连接关闭");

        return re;
    }
}