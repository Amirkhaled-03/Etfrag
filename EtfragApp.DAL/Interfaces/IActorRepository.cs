using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
    public interface IActorRepository :IGenericRepository<Actor>
    {
        public IEnumerable<Actor> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName);
        public int GetTotalActorFilmsCount(int actorId);
        public int GetTotalActorSeriesCount(int actorId);
    }
}
