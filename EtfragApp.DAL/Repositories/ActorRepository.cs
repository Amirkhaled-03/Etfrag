using EtfragApp.BLL.Interfaces;
using EtfragApp.DAL.Context;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(CinemaAppContextMVC context) : base(context)
        {
        }

        public int GetTotalActorFilmsCount(int actorId)
        {
            return _context.MovieActor.Count(ma => ma.ActorId == actorId);
        }

        public int GetTotalActorSeriesCount(int actorId)
        {
            return _context.TVSeriesActors.Count(sa => sa.ActorId == actorId);
        }

        public IEnumerable<Actor> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName)
        {
            var query = _context.Actors.Where(
              a => a.FirstName
                    .Trim()
                    .ToLower()
                    .Contains
                     (
                      searchName.Trim()
                      .ToLower()
                     )
              ||
                   a.LastName
                    .Trim()
                    .ToLower()
                    .Contains
                     (
                      searchName.Trim()
                      .ToLower()
                     )
              );

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);

        }
    
    }
}
