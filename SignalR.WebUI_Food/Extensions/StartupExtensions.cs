using Microsoft.AspNetCore.Identity;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.CustomValidations;
using SignalR.WEB_Food.Locations;

namespace SignalR.WEB_Food.Extensions
{
    public static class StartupExtensions
    {

        public static void AddIdentityWithExt(this IServiceCollection services)
        {

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(2);//parola yenileme için oluşturulan token'a süre belirledik.2 saat sonra token kullanılmayacak hale gelecek.
            });


            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_";
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;

            }).
            AddPasswordValidator<PasswordValidator>().
            AddUserValidator<UserValidator>().
            AddErrorDescriber<LocationIdentityErrorDescriber>().
            AddDefaultTokenProviders().
            AddEntityFrameworkStores<SignalRContext>();
        }
    }
}
