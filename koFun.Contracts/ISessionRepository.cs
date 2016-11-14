using System.Linq;
using koFun.Model;

namespace koFun.Contracts
{
    public interface ISessionRepository
    {
        IQueryable<SessionBrief> GetSessionBriefs();
        IQueryable<Session> GetAll();
        Session FindOne(int id);
        void Add(Session session);
        void Update(Session session);
        void Delete(int id);
    }
}