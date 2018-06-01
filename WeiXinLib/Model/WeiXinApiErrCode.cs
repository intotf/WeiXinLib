using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// 错误回调实体
    /// </summary>
    public class WeiXinApiErrCode
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误提示信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
