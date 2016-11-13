using System.Data.Entity;

namespace koFun.Data.SampleData
{
    public class CodeCamperInitializer : DropCreateDatabaseIfModelChanges<CodeCamperDbContext>
    {
        private const int AttendeeCount = 1000;
        private const int AttendeesWithFavoritesCount = 4;

        protected override void Seed(CodeCamperDbContext context)
        {
            base.Seed(context);
        }
    }
}