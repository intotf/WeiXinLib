using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// 微信二维码请求参数
    /// </summary>
    public class QrCodeConfig
    {
        /// <summary>
        /// 二维码的宽度
        /// </summary>
        private int _width = 430;

        /// <summary>
        /// 小程序的页面
        /// 设置参数，参数间用&符号隔开
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 二维码的宽度
        /// 默认 430
        /// </summary>
        public int width
        {
            get { return this._width; }
            set { this._width = value; }
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public QrCodeConfig()
        {

        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path">小程序地址</param>
        public QrCodeConfig(string path)
        {
            this.path = path;
        }
    }
}
