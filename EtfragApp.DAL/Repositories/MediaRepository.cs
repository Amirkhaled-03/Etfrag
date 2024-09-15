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
    public class MediaRepository : GenericRepository<Media>, IMediaRepository
    {
        public MediaRepository(CinemaAppContextMVC context) : base(context)
        {
        }
    }
}
