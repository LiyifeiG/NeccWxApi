using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeccWxApi.Servers
{
    /// <summary>
    /// 分数线Server
    /// </summary>
    public static class AdmitLineServer
    {
        /// <summary>
        /// 获得所有的分数线数据
        /// </summary>
        /// <returns>所有的分数线数据</returns>
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
