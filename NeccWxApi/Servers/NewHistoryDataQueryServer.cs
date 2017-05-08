using System.Collections.Generic;
using System.Data.SqlClient;
using NeccWxApi.Models;

namespace NeccWxApi.Servers
{
    public class NewHistoryDataQueryServer
    {
        /// <summary>
        /// 精确查询学校
        /// </summary>
        /// <param name="qunpm">查询参数</param>
        /// <param name="localProvince">生源地</param>
        /// <returns>查询结果</returns>
        public static IEnumerable<object> QueryUniversity(QUniNameParModel qunpm, string localProvince)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                if (qunpm.classes == null) //如果没有必须的参数，则返回错误信息
                {
                    return new List<object>
                    {
                        new
                        {
                            code = "306",
                            msg = "No necessary parameters"
                        }
                    };
                }

                string sqlUniBatch = " ", sqlUniType = " ", sqlUniLocal = " ", sqlYear = " ";
                if (qunpm.uniBatch != null)
                {
                    sqlUniBatch = " and batch = '" + qunpm.uniBatch + "' ";
                }
                if (qunpm.uniLocal != null)
                {
                    sqlUniLocal = " and University.address = '" + qunpm.uniLocal + "' ";
                }
                if (qunpm.uniType != null)
                {
                    sqlUniType = " and University.subject = '" + qunpm.uniType + "' ";
                }
                if (qunpm.year != 0)
                {
                    sqlYear = " and year = " + qunpm.year + " ";
                }

                con.Open();
                var re = new List<object>();

                var sqlStr =
                    "SELECT DISTINCT " + Server.Province[localProvince] +
                    "Admit.uniName  , address , University.subject , batch , year , uniMin , uniAve , uniGap , uniNum " +
                    "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                    Server.Province[localProvince] +
                    "Admit.uniName = University.uniName " +
                    "WHERE province = '" + localProvince + "' " + " AND classes = '" + qunpm.classes + "' " +
                    "AND University.uniName like '%" + qunpm.uniName + "%' " + sqlUniBatch + sqlUniLocal + sqlUniType +
                    sqlYear +
                    " ORDER BY uniMin";

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
        /// 精确查询专业
        /// </summary>
        /// <param name="qpnpm">查询参数</param>
        /// <param name="localProvince">生源地</param>
        /// <returns>查询结果</returns>
        public static IEnumerable<object> QueryProfession(QProNameParModel qpnpm, string localProvince)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                if (qpnpm.classes == null || qpnpm.year == 0 || qpnpm.rScore == 0)
                {
                    return new List<object>
                    {
                        new
                        {
                            code = "306",
                            msg = "No necessary parameters"
                        }
                    };
                }


                string sqlUniLocal = " ", sqlProBatch = " ";

                if (qpnpm.uniLocal != null)
                {
                    sqlUniLocal = " and University.address = '" + qpnpm.uniLocal + "' ";
                }
                if (qpnpm.proBatch != null)
                {
                    sqlProBatch = " and batch = '" + qpnpm.proBatch + "' ";
                }

                con.Open();
                var re = new List<object>();

                var sqlStr =
                    "SELECT DISTINCT proName , " + Server.Province[localProvince] +
                    "Admit.uniName , address , batch , proMin , proAve , proMinP , proNum " +
                    "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                    Server.Province[localProvince] +
                    "Admit.uniName = University.uniName " +
                    "WHERE province = '" + localProvince + "' AND year = " + qpnpm.year + " AND classes = '" +
                    qpnpm.classes + "'" + sqlUniLocal + sqlProBatch +
                    "AND (proMin <= " + qpnpm.rScore + " AND proMin >= " + qpnpm.lScore + " ) AND proname like '%" +
                    qpnpm.proName + "%' ORDER BY proMin";

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
        /// 分数查询
        /// </summary>
        /// <param name="qspm">查询参数头</param>
        /// <param name="localProvince">生源地</param>
        /// <returns>查询结果</returns>
        public static IEnumerable<object> QueryScore(QScoreParModel qspm, string localProvince)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                if (qspm.classes == null || qspm.year == 0 || qspm.rScore == 0)
                {
                    return new List<object>
                    {
                        new
                        {
                            code = "306",
                            msg = "No necessary parameters"
                        }
                    };
                }


                string sqlUniLocal = " ", sqlBatch = " ";

                if (qspm.uniLocal != null)
                {
                    sqlUniLocal = " and University.address = '" + qspm.uniLocal + "' ";
                }
                if (qspm.batch != null)
                {
                    sqlBatch = " and batch = '" + qspm.batch + "' ";
                }

                con.Open();
                var re = new List<object>();

                var sqlStr =
                    "SELECT DISTINCT " + Server.Province[localProvince] +
                    "Admit.uniName  , address , batch ,  uniMin , uniAve , uniMinP , uniNum " +
                    "FROM " + Server.Province[localProvince] + "Admit JOIN University ON " +
                    Server.Province[localProvince] +
                    "Admit.uniName = University.uniName " +
                    "WHERE province = '" + localProvince + "' " + sqlUniLocal + sqlBatch +
                    " AND classes = '" + qspm.classes + "'" +
                    "AND uniMin >= " + qspm.lScore + " AND uniMin <= " + qspm.rScore + " AND year = " + qspm.year +
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
        /// 获得所有院校所在地
        /// </summary>
        /// <returns>所有院校所在地</returns>
        public static IEnumerable<object> AllUniLocal()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                const string sqlStr = "SELECT DISTINCT address FROM University";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    if ((string) reader[0] != "" && (string) reader[0] != "null")
                        re.Add(new
                        {
                            local = (string) reader[0]
                        });
                }
                return re;
            }
        }

        /// <summary>
        /// 所有的院校类型
        /// </summary>
        /// <returns>所有的院校类型</returns>
        public static IEnumerable<object> AllUniType()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                const string sqlStr = "SELECT DISTINCT subject FROM University";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    if ((string) reader[0] != "" && (string)reader[0] != "null")
                        re.Add(new
                        {
                            type = (string) reader[0]
                        });
                }
                return re;
            }
        }

        /// <summary>
        /// 所有的批次
        /// </summary>
        /// <returns>所有的批次</returns>
        public static IEnumerable<object> AllUniBatch()
        {
            return new List<object>
            {
                new {batch = "本科一批"},
                new {batch = "本科二批"},
                new {batch = "本科提前批"},
                new {batch = "本科三批"},
                new {batch = "专科提前批"},
                new {batch = "高职高专批"}
            };
        }
    }
}