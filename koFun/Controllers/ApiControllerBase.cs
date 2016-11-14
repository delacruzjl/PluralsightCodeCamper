using System.Web.Http;
using koFun.Contracts;

namespace koFun.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected ICodeCamperUow Uow { get; set; }
    }
}