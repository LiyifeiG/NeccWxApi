using System.Data;
using System.Data.SqlClient;

namespace NeccWxApi
{
    public class UniversityServer
    {
        /// <summary>
        /// get university detail information
        /// </summary>
        /// <returns>the university detail information</returns>
        public static object GetUniversity(string uniName)
        {
            DBLink.Log("开始连接");
            var con = DBLink.Connect();
            if (con.State != ConnectionState.Open)
            {
                DBLink.Log("连接未打开");
                return null;
            }

            var sqlStr = "SELECT uniID , uniName , address , type , subject , eduBackg , residing , webSite " +
                         "FROM University WHERE uniName = '" + uniName + "'";

            var sc = new SqlCommand(sqlStr , con);

            sc.ExecuteNonQuery();

            var reader = sc.ExecuteReader();

            if (reader.Read())
            {
                return new
                {
                    院校ID = (int)reader[0] ,
                    院校名称 = (string)reader[1],
                    院校地点 = (string)reader[2],
                    办学类型 = (string)reader[3],
                    院校类型 = (string)reader[4],
                    办学层次 = (string)reader[5],
                    院校隶属 = (string)reader[6],
                    院校官网 = (string)reader[7]
                };
            }

            DBLink.DisConnect(con);

            DBLink.Log("连接关闭");

            return null;
        }
    }
}