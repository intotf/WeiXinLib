using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace WeiXinLib.Attribute
{
    /// <summary>
    /// 对微信文件进行特殊处理
    /// </summary>
    public class WeiXinStreamAttribute : AutoReturnAttribute
    {
        private static readonly Type weiXinApiResultType = typeof(WeiXinApiResult<>);

        protected async override Task<object> GetTaskResult(ApiActionContext context)
        {
            var dataType = context.ApiActionDescriptor.Return.DataType;
            if (dataType.IsGenericType == false || dataType.GetGenericTypeDefinition() != weiXinApiResultType)
            {
                return await base.GetTaskResult(context);
            }

            var stream = await context.ResponseMessage.Content.ReadAsStreamAsync();
            var genericType = dataType.GetGenericArguments().FirstOrDefault();
            var result = Activator.CreateInstance(dataType) as IWeiXinApiResult;

            if (stream == null)
            {
                var err = new WeiXinApiErrCode { errcode = 9999, errmsg = "获取二维码失败" };
                result.Error = err;
            }
            else
            {
                result.Data = stream;
                result.State = true;
            }
            return result;
        }
    }
}
