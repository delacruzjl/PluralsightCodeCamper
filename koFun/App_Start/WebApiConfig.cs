using System.Web.Http;

namespace koFun
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var mediaTypeFormatterCollection = config.Formatters;

            mediaTypeFormatterCollection
                .JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            
            mediaTypeFormatterCollection
                .Remove(mediaTypeFormatterCollection.XmlFormatter);

            config.MapHttpAttributeRoutes();
        }
    }
}