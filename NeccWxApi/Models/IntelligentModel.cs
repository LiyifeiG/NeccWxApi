namespace NeccWxApi.Models
{
    /// <summary>
    /// 智能查询模型
    /// </summary>
    public class IntelligentModel
    {
        /// <summary>
        /// 分数
        /// </summary>
        public int score { get; set; }
        /// <summary>
        /// 位次
        /// </summary>
        public int numP { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 学校类型
        /// </summary>
        public string uniType { get; set; }
        /// <summary>
        /// 学校隶属
        /// </summary>
        public string uniResiding { get; set; }
    }
}