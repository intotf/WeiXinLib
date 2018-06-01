using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace WeiXinLib
{
    /// <summary>
    /// 微信网页授权接口
    /// </summary>
    public static class Instance
    {
        /// <summary>
        /// 初始化接口
        /// </summary>
        private static readonly IOAuth client = HttpApiClient.Create<IOAuth>();

        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="secret">公众号的appsecret</param>
        /// <param name="code">填写第一步获取的code参数</param>
        /// <param name="grant_type">默认为authorization_code</param>
        /// <returns>AccessTokenResult 实体</returns>
        public static async Task<WeiXinApiResult<AccessTokenResult>> GetAccessTokenAsync(string appid, string secret, string code, string grant_type = "authorization_code")
        {
            var data = await client.GetAccessToken(appid, secret, code, grant_type).Retry(3, TimeSpan.FromSeconds(1))
                .WhenResult(item => item == null)
                .Handle()
                .WhenCatch<HttpRequestException>(ex =>
                {
                    return WeiXinApiResult<AccessTokenResult>.False(ex.HResult, ex.InnerException.Message);
                });
            return data;
        }

        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="access_token">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openid">用户的唯一标识</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public static async Task<WeiXinApiResult<UserInfoResult>> GetUserInfoAsync(string access_token, string openid, string lang = "zh_CN")
        {
            var data = await client.GetUserInfo(access_token, openid, lang).Retry(3, TimeSpan.FromSeconds(1))
                //.WhenResult(item => item == null)
                .Handle()
                .WhenCatch<HttpRequestException>(ex =>
                {
                    return WeiXinApiResult<UserInfoResult>.False(ex.HResult, ex.InnerException.Message);
                });
            return data;
        }

        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="refresh_token">填写为refresh_token</param>
        /// <param name="grant_type">默认认为refresh_token</param>
        /// <returns></returns>
        public static async Task<WeiXinApiResult<AccessTokenResult>> RefreshTokenAsync(string appid, string refresh_token, string grant_type = "refresh_token")
        {
            var data = await client.RefreshToken(appid, refresh_token, grant_type).Retry(3, TimeSpan.FromSeconds(1))
                //.WhenResult(item => item == null)
                .Handle()
                .WhenCatch<HttpRequestException>(ex =>
                {
                    return WeiXinApiResult<AccessTokenResult>.False(ex.HResult, ex.InnerException.Message);
                });
            return data;
        }
    }
}
