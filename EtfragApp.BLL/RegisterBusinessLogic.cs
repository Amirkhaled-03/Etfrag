using EtfragApp.BLL.ServicesContracts;
using EtfragApp.BLL.Sevices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL
{
    public static class RegisterBusinessLogic
    {
        public static void RegisterBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITVSeriesService, TVSeriesService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAccountService, AccountService>();

        }
    }
}
