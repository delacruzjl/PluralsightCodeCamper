using System;
using koFun.Contracts;
using koFun.Data.Helpers;
using koFun.Model;

namespace koFun.Data
{
    public class CodeCamperUow : ICodeCamperUow
    {
        public CodeCamperUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }
        protected CodeCamperDbContext DbContext { get; set; }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IRepository<Room> Rooms => GetStandardRepo<Room>();
        public IRepository<TimeSlot> TimeSlots => GetStandardRepo<TimeSlot>();
        public IRepository<Track> Tracks => GetStandardRepo<Track>();
        public ISessionRepository Sessions => GetRepo<ISessionRepository>();
        public IAttendanceRepository Attendances => GetRepo<IAttendanceRepository>();
        public IPersonRepository Persons => GetRepo<IPersonRepository>();

        protected void CreateDbContext()
        {
            DbContext = new CodeCamperDbContext();

            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            GC.SuppressFinalize(this);
            DbContext.Dispose();
        }
    }
}