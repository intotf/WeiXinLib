using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace WeiXinLib
{
    /// <summary>
    /// 微信常用接口
    /// </summary>
    [HttpHost("https://api.weixin.qq.com")]
    public interface IOAuth : IHttpApi
    {
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="secret">公众号的appsecret</param>
        /// <param name="code">填写第一步获取的code参数</param>
        /// <param name="grant_type">默认为authorization_code</param>
        /// <returns>AccessTokenResult 实体</returns>
        [HttpGet("/sns/oauth2/access_token")]
        [WeiXinReturn]
        ITask<WeiXinApiResult<AccessTokenResult>> GetAccessToken(string appid, string secret, string code, string grant_type);


        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="access_token">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openid">用户的唯一标识</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        [HttpGet("/sns/userinfo")]
        [WeiXinReturn]
        ITask<WeiXinApiResult<UserInfoResult>> GetUserInfo(string access_token, string openid, string lang);


        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="refresh_token">填写为refresh_token</param>
        /// <param name="grant_type">默认认为refresh_token</param>
        /// <returns></returns>
        [HttpGet("/sns/oauth2/refresh_token")]
        [WeiXinReturn]
        ITask<WeiXinApiResult<AccessTokenResult>> RefreshToken(string appid, string refresh_token, string grant_type);
    }
}
