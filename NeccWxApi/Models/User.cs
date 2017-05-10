namespace NeccWxApi.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户电话号码
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 用户激活码
        /// </summary>
        public string ActiveCode { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
    }


}