using System;
using koFun.Model;

namespace koFun.Contracts
{
    public interface ICodeCamperUow : IDisposable
    {
        IRepository<Room> Rooms { get; }
        IRepository<TimeSlot> TimeSlots { get; }
        IRepository<Track> Tracks { get; }
        ISessionRepository Sessions { get; }
        IAttendanceRepository Attendances { get; }
        IPersonRepository Persons { get; }
        void Commit();
    }
}