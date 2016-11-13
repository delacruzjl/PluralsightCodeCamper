using System;
using koFun.Contracts;
using koFun.Model;

namespace koFun.Data
{
    public class CodeCamperUow : ICodeCamperUow
    {
        public CodeCamperUow()
        {
            CreateDbContext();
        }

        protected CodeCamperDbContext DbContext { get; set; }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IRepository<Room> Rooms { get; }
        public IRepository<TimeSlot> TimeSlots { get; }
        public IRepository<Track> Tracks { get; }
        public ISessionRepository Sessions { get; }
        public IAttendanceRepository Attendances { get; }
        public IPersonRepository Persons { get; }

        protected void CreateDbContext()
        {
            DbContext = new CodeCamperDbContext();

            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepository<T> GetStandardRepo<T>() where T : class
        {
            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            GC.SuppressFinalize(this);
            DbContext.Dispose();
        }
    }
}