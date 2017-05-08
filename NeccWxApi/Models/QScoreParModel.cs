namespace NeccWxApi.Models
{
    public class QScoreParModel
    {
        /// <summary>
        /// 科类
        /// </summary>
        public string classes { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int year { get; set; }
        /// <summary>
        /// 分数下限
        /// </summary>
        public int lScore { get; set; }
        /// <summary>
        /// 分数上限
        /// </summary>
        public int rScore { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 专业批次
        /// </summary>
        public string batch { get; set; }
    }
}