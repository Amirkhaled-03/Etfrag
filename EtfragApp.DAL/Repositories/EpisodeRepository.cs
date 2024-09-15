using EtfragApp.BLL.Interfaces;
using EtfragApp.DAL.Context;
using EtfragApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Repositories
{
    public class EpisodeRepository:GenericRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(CinemaAppContextMVC context) : base(context)
        {
        }
       
    }
}
