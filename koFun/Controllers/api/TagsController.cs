using System;
using System.Web.Http;

namespace koFun.Controllers
{
    [Route("api/tags")]
    public class TagsController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            var data = new[]
            {
                new {Id = 1, Name = "test 1", TimeStamp = DateTime.Now },
                new {Id = 2, Name = "test 2", TimeStamp = DateTime.Now },
                new {Id = 3, Name = "test 3", TimeStamp = DateTime.Now },
                new {Id = 4, Name = "test 4", TimeStamp = DateTime.Now },
                new {Id = 5, Name = "test 5", TimeStamp = DateTime.Now },
                new {Id = 6, Name = "test 6", TimeStamp = DateTime.Now }
            };

            return Ok(data);
        }
    }
}