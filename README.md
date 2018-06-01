# WeiXinLib 是基于微信相关Api进行封装
对接微信相关接口封装，包含网页登录授权.......(后续有需要在增加其它接口，也可以跟据现接口自己增加)

## 简介
- 所以接口采用异步调用，如出现异常重试3次
- 使用该Lib 返回Rest风格，准确的将微信验证失败、Http请求异常展示出来。
- 后期扩展方便；



### 授权登录
微信官方说明文档：https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140842

##### 1、通过code换取网页授权access_token
```
GetAccessTokenAsync(string appid, string secret, string code, string grant_type);
```

##### 2、通过Access_Token 获取用户信息
```
GetUserInfoAsync(string access_token, string openid, string lang = "zh_CN")
```

##### 3、刷新access_token（一般不使用）
```
RefreshTokenAsync(string appid, string refresh_token, string grant_type = "refresh_token")

```

##### 4、授权登录单元测试
    WeiXinLibTest.IOAuthUnitTest




