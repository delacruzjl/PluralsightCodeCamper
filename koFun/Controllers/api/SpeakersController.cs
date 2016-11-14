using System.Linq;
using System.Web.Http;
using koFun.Contracts;

namespace koFun.Controllers
{
    [Route("api/speakers")]
    public class SpeakersController : ApiControllerBase
    {
        public SpeakersController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        public IHttpActionResult Get()
        {
            return Ok(Uow
                .Persons
                .GetSpeaker()
                .OrderBy(_ => _.FirstName));
        }
    }
}