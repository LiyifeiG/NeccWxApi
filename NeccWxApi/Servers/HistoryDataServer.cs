using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NeccWxApi;


public static class HistoryDataServer
{
    /// <summary>
    /// 全部专业列表
    /// </summary>
    // <param name="localProvince">生源地</param>
    /// <returns>专业列表</returns>
    public static List<object> GetProfessionList(string localProvince)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();

            var re = new List<object>();


            var sqlStr = "SELECT DISTINCT proID , proName FROM " + Server.Province[localProvince] +
                         "Admit  ORDER BY proName";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

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

            Server.Log("获得结果 " + re.Count + "条");

            return re;
        }
    }

    /// <summary>
    /// 全部院校列表
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <returns>学校列表</returns>
    public static List<object> GetUniversityList(string localProvince)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();

            var sqlStr = "SELECT DISTINCT uniID , uniName FROM " + Server.Province[localProvince] +
                         "Admit ORDER BY uniName";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    院校ID = (int)reader[0],
                    院校名称 = (string)reader[1]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");

            return re;
        }
    }

    /// <summary>
    /// 专业查询
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <param name="year">年份</param>
    /// <param name="classes">类别</param>
    /// <param name="lscore">分数下限</param>
    /// <param name="rscore">分数上限</param>
    /// <param name="proName">专业名称</param>
    /// <returns>专业列表</returns>
    public static IEnumerable<object> QueryProfession(string localProvince, int year, string classes, int lscore,
        int rscore, string proName)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();

            var sqlStr =
                "SELECT DISTINCT proName , " + Server.Province[localProvince] +
                "Admit.uniName , address , batch , proMin , proAve , proMinP , proNum " +
                "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                Server.Province[localProvince] +
                "Admit.uniName = University.uniName " +
                "WHERE province = '" + localProvince + "' AND year = " + year + " AND classes = '" + classes + "'" +
                "AND (proMin < " + rscore + " AND proMin > " + lscore + " ) AND proname like '%" +
                proName + "%' ORDER BY proMin";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    专业名称 = (string)reader[0],
                    院校名称 = (string)reader[1],
                    院校所在地 = (string)reader[2],
                    批次 = (string)reader[3],
                    专业最低分 = (int)reader[4],
                    专业平均分 = (double)reader[5],
                    专业最低位次 = (int)reader[6],
                    专业录取人数 = (int)reader[7]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");
            return re;
        }
    }

    /// <summary>
    /// 院校查询
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <param name="classes">类别</param>
    /// <param name="uniName">院校名称</param>
    /// <returns>院校列表</returns>
    public static IEnumerable<object> QueryUniversity(string localProvince, string classes, string uniName)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();

            var sqlStr =
                "SELECT DISTINCT " + Server.Province[localProvince] +
                "Admit.uniName  , address , University.type , batch , year , uniMin , uniAve , uniGap , uniNum " +
                "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                Server.Province[localProvince] +
                "Admit.uniName = University.uniName " +
                "WHERE province = '" + localProvince + "' " + " AND classes = '" + classes + "' " +
                "AND University.uniName like '%" +
                uniName + "%' ORDER BY uniMin";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    院校名称 = (string)reader[0],
                    院校所在地 = (string)reader[1],
                    院校类型 = (string)reader[2],
                    批次 = (string)reader[3],
                    年份 = (int)reader[4],
                    院校最低分 = (int)reader[5],
                    院校平均分 = (double)reader[6],
                    院校录取线差 = (decimal)reader[7],
                    院校录取人数 = (int)reader[8]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");

            return re;
        }
    }

    /// <summary>
    /// 分数查询
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <param name="year">年份</param>
    /// <param name="classes">类别</param>
    /// <param name="lscore">分数下限</param>
    /// <param name="rscore">分数上限</param>
    /// <returns>学校列表</returns>
    public static IEnumerable<object> QueryScore(string localProvince, int year, string classes, int lscore, int rscore)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();

            var sqlStr =
                "SELECT DISTINCT " + Server.Province[localProvince] +
                "Admit.uniName  , address , batch ,  uniMin , uniAve , uniMinP , uniNum " +
                "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                Server.Province[localProvince] +
                "Admit.uniName = University.uniName " +
                "WHERE province = '" + localProvince + "' " + " AND classes = '" + classes + "'" +
                "AND uniMin > " + lscore + " AND uniMin < " + rscore + " AND year = " + year +
                "ORDER BY uniMin";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    院校名称 = (string)reader[0],
                    院校所在地 = (string)reader[1],
                    批次 = (string)reader[2],
                    院校最低分 = (int)reader[3],
                    院校平均分 = (double)reader[4],
                    院校最低位次 = (int)reader[5],
                    院校录取人数 = (int)reader[6]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");

            return re;
        }
    }

    /// <summary>
    /// 学校开设专业列表
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <param name="uniName">学校名称</param>
    /// <returns>专业列表</returns>
    public static IEnumerable<object> ProfessionListByUniversity(string localProvince, string uniName)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();


            var sqlStr = "SELECT DISTINCT proID , proName , uniName FROM " + Server.Province[localProvince] +
                         "Admit WHERE uniName = '" + uniName + "'  ORDER BY proName";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    专业ID = reader[0] == DBNull.Value ? "错误数据" : (string)reader[0],
                    专业名称 = (string)reader[1],
                    学校名称 = (string)reader[2]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");

            return re;
        }
    }

    /// <summary>
    /// 查询开设了某专业的学校
    /// </summary>
    /// <param name="localProvince">生源地</param>
    /// <param name="uniName">专业名称</param>
    /// <returns>学校列表</returns>
    public static IEnumerable<object> UniversityListByProfession(string localProvince, string proName)
    {
        using (var con = new SqlConnection(Server.SqlConString))
        {
            con.Open();
            var re = new List<object>();

            var sqlStr = "SELECT DISTINCT uniID , uniName , proName FROM " + Server.Province[localProvince] +
                         "Admit WHERE proName ='" + proName + "' ORDER BY uniName";

            var sc = new SqlCommand(sqlStr, con);

            Server.Log("开始查询并统计 : 语句为" + sqlStr);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            while (reader.Read())
            {
                re.Add(new
                {
                    院校ID = (int)reader[0],
                    院校名称 = (string)reader[1],
                    专业名称 = (string)reader[2]
                });
            }

            Server.Log("获得结果 " + re.Count + "条");


            return re;
        }
    }
}