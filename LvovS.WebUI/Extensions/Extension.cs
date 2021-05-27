using LvovS.WebUI.Facade;
using LvovS.WebUI.Interfaces;
using LvovS.WebUI.Repsotry.Concreate;
using LvovS.WebUI.Repsotry.Core;
using Microsoft.Extensions.DependencyInjection;

namespace LvovS.WebUI.Extensions
{
    public static class Extension
    {
        public static void LoadAll(this IServiceCollection services)
        {
            //services.AddTransient<IAccountContactRepstory, AccountContactRepstory>();
            //services.AddTransient<IContactRepstory, IContactRepstory>();
            //services.AddTransient<IIncidentRepstory, IncidentRepstory>();
            //services.AddTransient<IUnitOfWork,>
            services.AddScoped(typeof(IBaseRepstory<>), typeof(BaseRepstory<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
           // services.AddTransient<IContactFacade, ContactFacade>();

        }
    }
}