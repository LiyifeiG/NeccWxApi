using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace NeccWxApi
{
    public static class ProfessionServer
    {
        /// <summary>
        /// 查询专业信息
        /// </summary>
        /// <returns>专业信息</returns>
        public static object GetProfession(string proName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr =
                    "SELECT proID , proName , proNameE , field , discipline , degree , mainCoursed , introduction FROM " +
                    "Profession WHERE proName = '" + proName + "'";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    return new
                    {
                        pID = (string)reader[0],
                        pName = (string)reader[1],
                        pNameE = (string)reader[2],
                        pField = (string)reader[3],
                        pDiscipline = (string)reader[4],
                        pDegree = (string)reader[5],
                        pMainCourse = (string)reader[6],
                        pIntroduction = (string)reader[7]
                    };
                }

                return null;
            }
        }

        /// <summary>
        /// 获得某一一级学科类的专业
        /// </summary>
        /// <returns>专业列表</returns>
        /// <param name="fieldName">学科类名称</param>
        public static IEnumerable<object> GetProfessionFieldList(string fieldName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr =
                    "SELECT proID , proName FROM " +
                    "Profession WHERE field = '" + fieldName + "'";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pID = (string)reader[0],
                        pName = (string)reader[1]

                    });
                }

                return re;
            }
        }

        /// <summary>
        /// 获得某一二级学科类的专业
        /// </summary>
        /// <returns>专业列表</returns>
        /// <param name="disName">学科类名称</param>
        public static IEnumerable<object> GetProfessionDisciplineList(string disName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr =
                    "SELECT proID , proName FROM " +
                    "Profession WHERE discipline = '" + disName + "'";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        pID = (string)reader[0],
                        pName = (string)reader[1]

                    });
                }

                return re;
            }
        }


        /// <summary>
        /// 获得一级学科类列表
        /// </summary>
        /// <returns>学科类列表</returns>
        public static IEnumerable<object> FieldList()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr =
                    "SELECT distinct field FROM " +
                    "Profession";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add((string)reader[0]);
                }

                return re;
            }
        }

        /// <summary>
        /// 获得二级学科类列表
        /// </summary>
        /// <returns>学科类列表</returns>
        public static IEnumerable<object> DisciplineList()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr =
                    "SELECT distinct discipline FROM " +
                    "Profession";

                var sc = new SqlCommand(sqlStr, con);

                var re = new List<object>();

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add((string)reader[0]);
                }

                return re;
            }
        }

        /// <summary>
        /// 获得专业类别与专业对照表
        /// </summary>
        /// <returns>专业类别与专业对照表</returns>
        public static Dictionary<object , IEnumerable<object>> GetProfessionList()
        {
            var fieldList = FieldList();
            return fieldList.ToDictionary<object, object, IEnumerable<object>>(f => new {fieldName = (string) f},
                f => new List<object>(GetProfessionFieldList((string) f)));
        }
    }
}