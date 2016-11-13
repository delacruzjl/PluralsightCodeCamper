using System.Linq;
using koFun.Model;

namespace koFun.Contracts
{
    public interface IPersonRepository
    {
        IQueryable<Speaker> GetSpeaker();
    }
}