using LvovS.WebUI.Core;
using LvovS.WebUI.Models;
using LvovS.WebUI.Repsotry.Abstaract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace LvovS.WebUI.Extensions
{
    public static class IdentityInjectionExtensions
    {
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
    }
    public static class BaseExtensions
    {
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
    }
}