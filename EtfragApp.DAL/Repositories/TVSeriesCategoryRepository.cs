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
    public class TVSeriesCategoryRepository : GenericRepository<TVSeriesCategory>, ITVSeriesCategoryRepository
    {
        public TVSeriesCategoryRepository(CinemaAppContextMVC context) : base(context)
        {
        }
    }
}
