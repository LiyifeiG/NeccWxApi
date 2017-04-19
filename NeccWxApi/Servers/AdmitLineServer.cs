using System;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace NeccWxApi
{
    public static class AdmitLineServer
    {
        /// <summary>
        /// Get all score line
        /// </summary>
        /// <returns>The all score line.</returns>
        public static IEnumerable<object> GetAllAdmitLine(string localProvince)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var re = new List<object>();

                var sqlStr = "Select year , classes , underGraduateF , underGraduateS , underGraduateT , Specialty from AdmitLine " +
                    "Where province = '" + localProvince + "'";

                var sc = new SqlCommand(sqlStr, con);

                sc.ExecuteNonQuery();

                var reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(new
                    {
                        年份 = (int)reader[0],
                        类别 = (string)reader[1],
                        一本 = (int)reader[2],
                        二本 = (int)reader[3],
                        三本 = (int)reader[4],
                        专科 = (int)reader[5]
                    });
                }

                return re;
            }
        }
    }
}
