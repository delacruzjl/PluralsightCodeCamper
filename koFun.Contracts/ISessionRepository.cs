using System.Linq;
using koFun.Model;

namespace koFun.Contracts
{
    public interface ISessionRepository
    {
        IQueryable<SessionBrief> GetSessionBriefs();
    }
}