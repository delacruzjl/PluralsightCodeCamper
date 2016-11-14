using System.Linq;
using koFun.Model;

namespace koFun.Contracts
{
    public interface IPersonRepository
    {
        IQueryable<Speaker> GetSpeaker();
        IQueryable<Person> GetAll();
        Person FindOne(int id);
        void Update(Person person);
    }
}