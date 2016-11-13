using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using koFun.Data.Configurations;
using koFun.Data.SampleData;
using koFun.Model;

namespace koFun.Data
{
    public class CodeCamperDbContext : DbContext
    {
        static CodeCamperDbContext()
        {
            Database.SetInitializer(new CodeCamperInitializer());
        }

        public CodeCamperDbContext()
            : base("CodeCamper")

        {
        }

        public IDbSet<Session> Sessions { get; set; }
        public IDbSet<Person> Persons { get; set; }
        public IDbSet<Attendance> Attendance { get; set; }

        // Lookup Lists
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<TimeSlot> TimeSlots { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new SessionConfiguration());

            modelBuilder
                .Configurations
                .Add(new AttendanceConfiguration());
        }
    }
}