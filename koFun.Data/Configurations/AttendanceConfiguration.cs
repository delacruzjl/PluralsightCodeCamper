using System.Data.Entity.ModelConfiguration;
using koFun.Model;

namespace koFun.Data.Configurations
{
    public class AttendanceConfiguration
        : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(_ => new {_.SessionId, _.PersonId});

            HasRequired(a => a.Session)
                .WithMany(p => p.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Person)
                .WithMany(p => p.AttendanceList)
                .HasForeignKey(a => a.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
}