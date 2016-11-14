using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace koFun
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}