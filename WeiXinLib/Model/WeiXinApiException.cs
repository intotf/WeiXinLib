using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// 接口调用异常
    /// </summary>
    public class WeiXinApiException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误提示信息
        /// </summary>
        public new string Message { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ApiErrCode">错误实体</param>
        public WeiXinApiException(WeiXinApiErrCode err)
        {
            this.Message = string.Format("{0}.错误代码:{1}", err.errmsg, err.errcode);
            this.Code = err.errcode;
        }
    }
}
