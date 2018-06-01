using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeiXinLib;
using System.Threading.Tasks;
using System.Drawing;

namespace WeiXinTest
{
    /// <summary>
    /// 微信授权测试
    /// </summary>
    [TestClass]
    public class IOAuthUnitTest
    {
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAccessToken()
        {
            var s = await Instance.GetAccessTokenAsync("Appid", "公众号的appsecret", "code");
            Console.WriteLine(s.Error);
        }

        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetUserInfo()
        {
            var s = await Instance.GetUserInfoAsync("access_token", "openid");
            Console.WriteLine(s);
        }

        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task RefreshToken()
        {
            var s = await Instance.RefreshTokenAsync("Appid", "refresh_token(AccessTokenResult对象中获取)");
            Console.WriteLine(s);
        }

        /// <summary>
        /// 获取应用Access_Token
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAppAccessToken()
        {
            var s = await Instance.GetAppAccessTokenAsync("wx06a2d57b14a6b79e", "c1e3ca94f343bd1874cbd56c1375a18c");
            Console.WriteLine(s);
        }

        /// <summary>
        /// 获取小程序码文件流
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAppWXAcode()
        {

            var token = "10_L_cRXe-zCmJjfs2ZCjzmxmjnR22DcDon0IL-Z6HFWdlrfyGBy9UqrJpPKVmQrLAZNR5okGZZvN6Ux5gOnnCpw472KqkDwEATVAny0IddiqfH1JhWbAkaapUtDOPCjpKtnOK2TQwBsGFZkwRgLBQfAGACSH";
            var codeConfig = new WXACodeConfig("pages/index?query=1");
            var s = await Instance.GetAppWXAcodeAsync(token, codeConfig);
            var img = Image.FromStream(s.Data, true);

            Console.WriteLine(s);
        }


        /// <summary>
        /// 获取小程序二维码码文件流
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAppQrcode()
        {
            var token = "10_L_cRXe-zCmJjfs2ZCjzmxmjnR22DcDon0IL-Z6HFWdlrfyGBy9UqrJpPKVmQrLAZNR5okGZZvN6Ux5gOnnCpw472KqkDwEATVAny0IddiqfH1JhWbAkaapUtDOPCjpKtnOK2TQwBsGFZkwRgLBQfAGACSH";
            var codeConfig = new QrCodeConfig("pages/index?query=1");
            var s = await Instance.GetAppQrcodeAsync(token, codeConfig);
            var img = Image.FromStream(s.Data, true);

            Console.WriteLine(s);
        }
    }
}
