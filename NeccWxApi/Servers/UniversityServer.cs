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
                        院校ID = (int)reader[0],
                        院校名称 = (string)reader[1],
                        院校地点 = (string)reader[2],
                        办学类型 = (string)reader[3],
                        院校类型 = (string)reader[4],
                        办学层次 = (string)reader[5],
                        院校隶属 = (string)reader[6],
                        院校官网 = (string)reader[7]
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
                    re.Add(new { 学校名称 = (string)reader[0] });
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
                    re.Add(new { 学校名称 = (string)reader[0] });
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