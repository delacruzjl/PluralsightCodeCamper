using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Controllers
{
    [RoutePrefix("api/lookups")]
    public class LookupsController : ApiControllerBase
    {
        public LookupsController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        [Route("all"), Route("")]
        public IHttpActionResult Get()
        {
            var lookup =new Lookups
            {
                Rooms = GetRooms().ToList(),
                TimeSlots = GetTimeSlots().ToList(),
                Tracks = GetTracks().ToList()
            };

            return Ok(lookup);
        }

        [Route("rooms")]
        public IEnumerable<Room> GetRooms()
        {
            return Uow
                .Rooms
                .GetAll()
                .OrderBy(_ => _.Name);
        }

        [Route("timeslots")]
        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            return Uow
                .TimeSlots
                .GetAll();

        }

        [Route("tracks")]
        public IEnumerable<Track> GetTracks()
        {
            return Uow
                .Tracks
                .GetAll();
        }
    }
}