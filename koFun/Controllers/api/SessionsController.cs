using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Controllers
{
    [Route("api/sessions/{id?}", Name = "SessionAndId")]
    public class SessionsController : ApiControllerBase
    {
        public SessionsController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        public IEnumerable<SessionBrief> Get()
        {
            return Uow.Sessions.GetSessionBriefs().ToList();
        }

        public Session Get(int id)
        {
            return Uow.Sessions.FindOne(id);
        }

        public IHttpActionResult Post(Session session)
        {
            Uow.Sessions.Add(session);
            Uow.Commit();
            var link = new Uri(
                Url.Link("SessionAndId", new {id = session.Id}), UriKind.RelativeOrAbsolute);

            return Created(link, session);
        }

        public IHttpActionResult Put(Session session)
        {
            Uow.Sessions.Update(session);
            Uow.Commit();
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            Uow.Sessions.Delete(id);
            Uow.Commit();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}