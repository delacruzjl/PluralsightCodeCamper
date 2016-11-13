using System.Data.Entity.ModelConfiguration;
using koFun.Model;

namespace koFun.Data.Configurations
{
    public class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            HasRequired(s => s.Speaker)
                .WithMany(p => p.SpeakerSessions)
                .HasForeignKey(s => s.SpeakerId);
        }
    }
}