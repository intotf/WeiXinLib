using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeiXinLib;
using System.Threading.Tasks;

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
    }
}
