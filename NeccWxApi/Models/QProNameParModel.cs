namespace NeccWxApi.Models
{
    /// <summary>
    /// 专业查询模型
    /// </summary>
    public class QProNameParModel
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
        /// 专业名称
        /// </summary>
        public string proName { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 专业批次
        /// </summary>
        public string proBatch { get; set; }
    }
}