using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinLib
{
    /// <summary>
    /// 获取小程序码请求配置
    /// </summary>
    public class WXACodeConfig : QrCodeConfig
    {
        /// <summary>
        /// 是否自动颜色
        /// </summary>
        private bool _autoColor = true;

        /// <summary>
        /// 是否透明底色
        /// </summary>
        private bool _isHyaline = true;

        /// <summary>
        /// 线条颜色
        /// </summary>
        private LineColor _lineColor = new LineColor();

        /// <summary>
        /// 自动配置线条颜色
        /// 如果颜色依然是黑色
        /// 则说明不建议配置主色调
        /// </summary>
        public bool auto_color
        {
            get { return this._autoColor; }
            set { this._autoColor = value; }
        }

        /// <summary>
        /// auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"0","g":"0","b":"0"} 十进制表示
        /// </summary>
        public LineColor line_color
        {
            get { return this._lineColor; }
            set { this._lineColor = value; }
        }

        /// <summary>
        /// 是否需要透明底色， is_hyaline 为true时，生成透明底色的小程序码
        /// </summary>
        public bool is_hyaline
        {
            get { return this._isHyaline; }
            set { this._isHyaline = value; }
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WXACodeConfig()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path">小程序地址</param>
        public WXACodeConfig(string path)
            : base(path)
        {
        }
    }
}
