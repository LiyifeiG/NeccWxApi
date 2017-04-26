using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NeccWxApi.Servers
{
    public static class IntelligentServer
    {
        /// <summary>
        /// 智能推荐
        /// </summary>
        /// <returns>推荐的学校列表</returns>
        /// <param name="score">分数</param>
        /// <param name="pnum">位次</param>
        /// <param name="localProvince">省份</param>
        /// <param name="classes">科类</param>
        /// <param name="year">年份</param>
        public static IEnumerable<object> IntelligentRecommendation(decimal score , int pnum , string localProvince , string classes , int year)
        {
            using(var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();
                var re = new List<object>();
                var sqlCom = new SqlCommand("sp_intellij" , con) { CommandType = System.Data.CommandType.StoredProcedure };

                sqlCom.Parameters.Add("@nScore" , System.Data.SqlDbType.Decimal);
                sqlCom.Parameters.Add("@npnum", System.Data.SqlDbType.Int);
                sqlCom.Parameters.Add("@province", System.Data.SqlDbType.NVarChar);
                sqlCom.Parameters.Add("@classes", System.Data.SqlDbType.NVarChar);
                sqlCom.Parameters.Add("@nYear", System.Data.SqlDbType.Int);

                sqlCom.Parameters["@nScore"].Value = score;
                sqlCom.Parameters["@npnum"].Value = pnum;
                sqlCom.Parameters["@province"].Value = localProvince;
                sqlCom.Parameters["@classes"].Value = classes;
                sqlCom.Parameters["@nYear"].Value = year;


                sqlCom.ExecuteNonQuery();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    re.Add(
                        new {
                        uID = (int)reader[0],
                        uName = (string)reader[1],
                        eduBackg = (string)reader[2],
                        uMax = (int)reader[3],
                        uMin = (int)reader[4],
                        uAve = (double)reader[5],
                        uMinP = (int)reader[6],
                        uMaxP = (int)reader[7],
                        uBatch = (string)reader[8],
                        uGap = (decimal)reader[9]
                    }
                    );
                }

                return re;
            }
        }
    }
}
