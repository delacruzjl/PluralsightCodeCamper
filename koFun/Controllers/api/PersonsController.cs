using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Controllers
{
    [Route("api/persons/{id?}")]
    public class PersonsController : ApiControllerBase
    {
        public PersonsController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        public IEnumerable<Person> Get()
        {
            return Uow.Persons.GetAll().OrderBy(_ => _.FirstName);
        }

        public IHttpActionResult Get(int id)
        {
            var person = Uow.Persons.FindOne(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        public IHttpActionResult Put(Person person)
        {
            Uow.Persons.Update(person);
            Uow.Commit();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}