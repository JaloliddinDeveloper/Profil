using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Profil.Brokers.Storages;
using Profil.Services.Foundations.Users;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddTransient<IStorageBroker, StorageBroker>();

        builder.Services.AddTransient<IUserService, UserService>();

        var app = builder.Build();

        app.UseStaticFiles();

        app.MapControllerRoute(name: "def",
            pattern: "{controller=User}/{action=Index}/{id?}");

        app.Run();
    }
}