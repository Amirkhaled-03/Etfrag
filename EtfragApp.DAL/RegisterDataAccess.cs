using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL
{
    public static class RegisterDataAccess
    {
        public static void RegisterDataAccessServices(this IServiceCollection services)
        {
           services.AddScoped<IActorRepository, ActorRepository>();
           services.AddScoped<IMovieRepository, MovieRepository>();
           services.AddScoped<ITVSeriesRepository, TVSeriesRepository>();
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<IMovieRepository, MovieRepository>();
           services.AddScoped<IMediaRepository, MediaRepository>();
           services.AddScoped<IMovieCategoryRepository, MovieCategoryRepository>();
           services.AddScoped<IMovieActorRepository, MovieActorRepository>();
           services.AddScoped<ITVSeriesActorRepository, TVSeriesActorRepository>();
           services.AddScoped<ITVSeriesCategoryRepository, TVSeriesCategoryRepository>();
           services.AddScoped<IEpisodeRepository, EpisodeRepository>();
           services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
