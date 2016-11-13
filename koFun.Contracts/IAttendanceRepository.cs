using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koFun.Model;

namespace koFun.Contracts
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        IQueryable<Attendance> GetByPersonId(int id);
        IQueryable<Attendance> GetBySessionId(int id);
        Attendance GetById(int personId, int sessionId);
        void Delete(int personId, int sessionId);
    }
}
