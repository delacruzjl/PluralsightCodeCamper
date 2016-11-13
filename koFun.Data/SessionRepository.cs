using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Data
{
    public class SessionRepository: EFRepository<Session>, ISessionRepository
    {
        public SessionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<SessionBrief> GetSessionBriefs()
        {
            return DbSet
                .Select(s => new SessionBrief
                {
                    Id = s.Id,
                    Title = s.Title,
                    Code = s.Code,
                    SpeakerId = s.SpeakerId,
                    TrackId = s.TrackId,
                    TimeSlotId = s.TimeSlotId,
                    RoomId = s.RoomId,
                    Level = s.Level,
                    Tags = s.Tags
                });
        }
    }
}
