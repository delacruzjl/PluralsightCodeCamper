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
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Speaker> GetSpeaker()
        {
            return DbContext
                .Set<Session>()
                .Select(_ => _.Speaker)
                .Distinct()
                .Select(s => new Speaker
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    ImageSource = s.ImageSource
                });
        }
    }
}
