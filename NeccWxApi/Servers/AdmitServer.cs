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
	public static List<string> GetProfessionList()
    {
        DBLink.Log("开始连接");

        var con = DBLink.Connect();

        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");

            return null;
        }

        var re = new List<string>();

        const string sqlStr = "SELECT DISTINCT proName FROM sf_score_admit ORDER BY sf_score_admit.proName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
            re.Add(reader[0] as string);
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
    public static List<string> GetUniversityList()
    {
        DBLink.Log("开始连接");
        var con = DBLink.Connect();
        if (con.State != ConnectionState.Open)
        {
            DBLink.Log("连接未打开");
            return null;
        }

        var re = new List<string>();

        const string sqlStr = "SELECT DISTINCT uniName FROM sf_score_admit ORDER BY sf_score_admit.uniName";

        var sc = new SqlCommand(sqlStr , con);

        DBLink.Log("开始查询并统计 : 语句为" + sqlStr);

        sc.ExecuteNonQuery();

        var reader = sc.ExecuteReader();

        while (reader.Read())
        {
            re.Add(reader[0] as string);
        }

        DBLink.Log("获得结果 " + re.Count + "条");

        DBLink.DisConnect(con);

        DBLink.Log("连接关闭");

        return re;
    }
}