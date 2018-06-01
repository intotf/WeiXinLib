using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// 公众号的全局 access_token
    /// </summary>
    public class AppAccessTokenResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 凭证有效时间,默认：7200秒
        /// </summary>
        public int expires_in { get; set; }
    }
}
