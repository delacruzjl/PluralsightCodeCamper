using System.Web.Http;
using koFun.Filters;
using Newtonsoft.Json.Serialization;

namespace koFun
{
    public class CustomConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var mediaTypeFormatterCollection = config.Formatters;
            var json = mediaTypeFormatterCollection
                .JsonFormatter;

                json
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            json
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();

            mediaTypeFormatterCollection
                .Remove(mediaTypeFormatterCollection.XmlFormatter);

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}