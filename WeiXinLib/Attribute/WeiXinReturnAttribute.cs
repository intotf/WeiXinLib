using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace WeiXinLib
{
    public class WeiXinReturnAttribute : AutoReturnAttribute
    {
        private static readonly Type weiXinApiResultType = typeof(WeiXinApiResult<>);

        protected async override Task<object> GetTaskResult(ApiActionContext context)
        {
            var dataType = context.ApiActionDescriptor.Return.DataType;
            if (dataType.IsGenericType == false || dataType.GetGenericTypeDefinition() != weiXinApiResultType)
            {
                return await base.GetTaskResult(context);
            }

            //var txt = "{ \"access_token\":\"ACCESS_TOKEN\",\"expires_in\":7200,\"refresh_token\":\"REFRESH_TOKEN\",\"openid\":\"OPENID\",\"scope\":\"SCOPE\" }";
            var txt = await context.ResponseMessage.Content.ReadAsStringAsync();
            var genericType = dataType.GetGenericArguments().FirstOrDefault();
            var result = Activator.CreateInstance(dataType) as IWeiXinApiResult;

            if (txt.Contains("errcode"))
            {
                var err = (WeiXinApiErrCode)context.HttpApiConfig.JsonFormatter.Deserialize(txt, typeof(WeiXinApiErrCode));
                result.Error = err;
            }
            else
            {
                result.Data = context.HttpApiConfig.JsonFormatter.Deserialize(txt, genericType);
                result.State = true;
            }
            return result;
        }
    }
}
