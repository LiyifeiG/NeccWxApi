using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NeccWxApi
{
    public static class UniversityServer
    {
        /// <summary>
        /// 查询院校信息
        /// </summary>
        /// <param name="uniName">学校名称</param>
        /// <returns>院校信息</returns>
        public static object GetUniversity(string uniName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var sqlStr = "SELECT uniID , uniName , address , type , subject , eduBackg , residing , webSite " +
                             "FROM University WHERE uniName = '" + uniName + "'";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                if (reader.Read())
                {
                    return new
                    {
                        uID = (int)reader[0],
                        uName = (string)reader[1],
                        uAddress = (string)reader[2],
                        uType = (string)reader[3],
                        uSubject = (string)reader[4],
                        uEduBackg = (string)reader[5],
                        uResiding = (string)reader[6],
                        uWebSite = (string)reader[7]
                    };
                }

                return null;
            }
        }

        /// <summary>
        /// 获得985学校列表
        /// </summary>
        /// <returns>学校列表</returns>
        public static IEnumerable<object> Get985UniversityList()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                const string sqlStr = "select uniName from Project where project985 = '985'";

                var re = new List<object>();

                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new { uName = (string)reader[0] });
                }


                return re;
            }
        }

        /// <summary>
        /// 获得211学校列表
        /// </summary>
        /// <returns>学校列表</returns>
        public static IEnumerable<object> Get211UniversityList()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                const string sqlStr = "select uniName from Project where project211 = '211'";

                var re = new List<object>();

                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new { uName = (string)reader[0] });
                }

                return re;
            }
        }
        /// <summary>
        /// 判断学校是985还是211
        /// </summary>
        /// <returns>((985,211)|985|211)</returns>
        /// <param name="uniName">学校名称</param>
        public static object UniversityIs985Or211(string uniName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlStr = "select uniName , project985 , project211 from Project where uniName = '" + uniName + "'";

                var sc = new SqlCommand(sqlStr, con);
                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    if ((int)reader[1] == 985)
                    {
                        if ((int)reader[2] == 211)
                        {
                            return new { msg = "985,211" };
                        }
                        return new { msg = "985" };
                    }
                    if ((int)reader[2] == 211)
                    {
                        return new { msg = "211" };
                    }
                    return new { msg = "000" };
                }
                return new { msg = "000" };

            }
        }
    }
}