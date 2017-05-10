using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeccWxApi.Servers
{
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

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pID = reader[0] == DBNull.Value ? "data wrong" : (string) reader[0],
                        pName = (string) reader[1]
                    });
                }

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

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        uID = (int) reader[0],
                        uName = (string) reader[1]
                    });
                }

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
                    "AND (proMin <= " + rscore + " AND proMin >= " + lscore + " ) AND proname like '%" +
                    proName + "%' ORDER BY proMin";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pName = (string) reader[0],
                        uName = (string) reader[1],
                        uAddress = (string) reader[2],
                        pBatch = (string) reader[3],
                        pMin = (int) reader[4],
                        pAve = (decimal) reader[5],
                        pMinP = (int) reader[6],
                        pNum = (int) reader[7]
                    });
                }

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

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        uName = (string) reader[0],
                        uAddress = (string) reader[1],
                        uType = (string) reader[2],
                        uBatch = (string) reader[3],
                        year = (int) reader[4],
                        uMin = (int) reader[5],
                        uAve = (decimal) reader[6],
                        uGap = (decimal) reader[7],
                        uNum = (int) reader[8]
                    });
                }

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
                    "AND uniMin >= " + lscore + " AND uniMin <= " + rscore + " AND year = " + year +
                    "ORDER BY uniMin";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        uName = (string) reader[0],
                        uAddress = (string) reader[1],
                        uBatch = (string) reader[2],
                        uMin = (int) reader[3],
                        uAve = (decimal) reader[4],
                        uMinP = (int) reader[5],
                        uNum = (int) reader[6]
                    });
                }

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

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pID = reader[0] == DBNull.Value ? "错误数据" : (string) reader[0],
                        pName = (string) reader[1],
                        uName = (string) reader[2]
                    });
                }

                return re;
            }
        }

        /// <summary>
        /// 查询开设了某专业的学校
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="proName">专业名称</param>
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

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pID = (int) reader[0],
                        uName = (string) reader[1],
                        pName = (string) reader[2]
                    });
                }

                return re;
            }
        }

        /// <summary>
        /// 获得学校的具体专业信息
        /// </summary>
        /// <param name="localProvince">生源地</param>
        /// <param name="uniName">学校名</param>
        /// <returns></returns>
        public static IEnumerable<object> ProfessionListByDetailUniversity(string localProvince, string uniName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var re = new List<object>();


                var sqlStr = "SELECT DISTINCT uniName , proName , year , proAve , proMin , proMinP , proNum  FROM " +
                             Server.Province[localProvince] +
                             "Admit WHERE uniName = '" + uniName + "'  ORDER BY proName";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        uName = (string) reader[0],
                        pName = (string) reader[1],
                        year = (int) reader[2],
                        pAve = (decimal) reader[3],
                        pMin = (int) reader[4],
                        pMinP = (int) reader[5],
                        pNum = (int) reader[6]
                    });
                }

                return re;
            }
        }

    }
}