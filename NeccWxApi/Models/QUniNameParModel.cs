namespace NeccWxApi.Models
{
    /// <summary>
    /// 校名精确查询模型
    /// </summary>
    public class QUniNameParModel
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
        /// 学校名称
        /// </summary>
        public string uniName { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 学校类型
        /// </summary>
        public string uniType { get; set; }
        /// <summary>
        /// 学校批次
        /// </summary>
        public string uniBatch { get; set; }
    }
}