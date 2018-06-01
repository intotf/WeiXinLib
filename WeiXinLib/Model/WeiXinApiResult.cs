using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// WeiXinApi接口返回对象接口
    /// </summary>
    public interface IWeiXinApiResult
    {
        /// <summary>
        /// 错识信息
        /// </summary>
        WeiXinApiErrCode Error { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        bool State { get; set; }

        /// <summary>
        /// 数据类容
        /// </summary>
        object Data { get; set; }
    }

    /// <summary>
    /// 微信接口返回实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeiXinApiResult<T> : IWeiXinApiResult where T : class,new()
    {
        /// <summary>
        /// 错识信息
        /// </summary>
        public WeiXinApiErrCode Error { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 数据类容
        /// </summary>
        public T Data { get; set; }


        object IWeiXinApiResult.Data
        {
            get
            {
                return this.Data;
            }
            set
            {
                this.Data = (T)value;
            }
        }

        public static WeiXinApiResult<T> True(T data)
        {
            return new WeiXinApiResult<T> { Data = data, State = true };
        }


        public static WeiXinApiResult<T> False(int code, string msg)
        {
            return new WeiXinApiResult<T> { Data = null, State = false, Error = new WeiXinApiErrCode { errcode = code, errmsg = msg } };
        }
    }
}


 