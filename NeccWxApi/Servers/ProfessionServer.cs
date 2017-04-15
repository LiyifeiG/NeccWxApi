using System.Data.SqlClient;

namespace NeccWxApi
{
    public class ProfessionServer
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

                if (reader.Read())
                {
                    return new
                    {
                        专业ID = (string) reader[0],
                        专业名称 = (string) reader[1],
                        英文名称 = (string) reader[2],
                        专业类型 = (string) reader[3],
                        院校具体类型 = (string) reader[4],
                        所授学位 = (string) reader[5],
                        主修课程 = (string) reader[6],
                        专业简介 = (string) reader[7]
                    };
                }

                return null;
            }
        }
    }
}