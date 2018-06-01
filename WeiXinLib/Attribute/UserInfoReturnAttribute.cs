using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace WeiXinLib
{
    public class UserInfoReturnAttribute : ApiReturnAttribute
    {

        public UserInfoReturnAttribute()
        {

        }

        protected async override Task<object> GetTaskResult(ApiActionContext context)
        {
            var txt = await context.ResponseMessage.Content.ReadAsStringAsync();
            if (txt.Contains("errcode"))
            {
                var err = (WeiXinApiErrCode)context.HttpApiConfig.JsonFormatter.Deserialize(txt, typeof(WeiXinApiErrCode));
                throw new WeiXinApiException(err);
            }
            else
            {
                var data = (UserInfoResult)context.HttpApiConfig.JsonFormatter.Deserialize(txt, typeof(UserInfoResult));
                return WeiXinApiResult<UserInfoResult>.True(data);
            }
        }
    }
}
