using AutoMapper;
using LvovS.WebUI.Core;
using LvovS.WebUI.Facades;
using LvovS.WebUI.Interfaces.Facade;
using LvovS.WebUI.Interfaces.Services;
using LvovS.WebUI.Mappers;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Concreate;
using LvovS.WebUI.Repsotry.Core;
using LvovS.WebUI.Services;
using LvovS.WebUI.Services.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace LvovS.WebUI.Extensions
{
    public static class Extension
    {
        #region ::LoadAll::

        /// <summary>
        /// This is All Services Load
        /// </summary>
        /// <param name="services"></param>
        public static void LoadAll(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepstory<>), typeof(BaseRepstory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped<IAccountContactService, AccountContactService>();
            services.AddScoped<IAccountService, AcountService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IIncidentService, IncidentService>();

            services.AddScoped<IAcountFacade, AccountFacade>();
            services.AddScoped<IAccountContactFacade, AccountContactFacade>();
            services.AddScoped<IContactFacade, ContactFacade>();
            services.AddScoped<IIncidentFacade, IncidentFacade>();
        }

        #endregion ::LoadAll::

        #region ::IdentityLoad::

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public static void IdentityLoad(this IServiceCollection services)
        {
            services.AddIdentity<Account, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<AccountContactDBContext>
                ().AddDefaultTokenProviders();
        }

        #endregion ::IdentityLoad::

        #region ::Mapped::

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Mapped<T>(this object query)
        {
            if (query != null)
            {
                Type TargetType = typeof(T);
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Mapped<T>(this object query, object obj)
        {
            if (query != null)
            {
                Type TargetType = obj.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        /// <summary>
        /// this is extension for mapped extend IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Mapped<T>(this IQueryable<T> query)
        {
            if (query != null)
            {
                Type TargetType = query.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        #endregion ::Mapped::

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}