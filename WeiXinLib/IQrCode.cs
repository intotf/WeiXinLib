using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;

namespace WeiXinLib
{
    [HttpHost("https://api.weixin.qq.com")]
    public interface IWeiXinApi : IHttpApi
    {
        
    }
}
