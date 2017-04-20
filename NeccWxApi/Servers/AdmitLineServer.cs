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
                        year = (int)reader[0],
                        classes = (string)reader[1],
                        underGraduateF = (int)reader[2],
                        underGraduateS = (int)reader[3],
                        underGraduateT = (int)reader[4],
                        specialty = (int)reader[5]
                    });
                }

                return re;
            }
        }
    }
}
