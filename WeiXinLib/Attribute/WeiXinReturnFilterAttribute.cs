using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace WeiXinLib
{
    /// <summary>
    /// 提交之前拦截器
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class WeiXinReturnFilterAttribute : ApiActionFilterAttribute
    {
        /// <summary>
        /// 数据提交前处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async override Task OnBeginRequestAsync(ApiActionContext context)
        {
            var json = await context.RequestMessage.ToStringAsync();

            base.OnBeginRequestAsync(context);
        }
    }
}
