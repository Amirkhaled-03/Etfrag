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
    public class MovieCategoryRepository : GenericRepository<MovieCategory>, IMovieCategoryRepository
    {
        public MovieCategoryRepository(CinemaAppContextMVC context) : base(context)
        {
        }

	}
}
