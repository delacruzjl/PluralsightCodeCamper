using System;
using System.Data.Entity;
using System.Linq;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Data
{
    public class AttendanceRepository : EFRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        [Obsolete("Cannot return a single attendance result", true)]
        public override Attendance FindOne(int id)
        {
            throw new InvalidOperationException("Cannot return a single attendance result");
        }

        [Obsolete("Cannot return a single attendance result", true)]
        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot return a single attendance result");
        }

        public IQueryable<Attendance> GetByPersonId(int id)
        {
            return DbSet
                .Where(_ => _.PersonId == id);
        }

        public IQueryable<Attendance> GetBySessionId(int id)
        {
            return DbSet
                .Where(_ => _.SessionId == id);
        }

        public Attendance GetById(int personId, int sessionId)
        {
            return DbSet
                .FirstOrDefault(s =>
                    (s.PersonId == personId) &&
                    (s.SessionId == sessionId));
        }

        public void Delete(int personId, int sessionId)
        {
            var entity = GetById(personId, sessionId);
            if (entity == null) return;

            Delete(entity);
        }
    }
}