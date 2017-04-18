using System.Data.SqlClient;

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
    }
}