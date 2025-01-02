using App.Domain.AppService.Core_App.CardAggrigate;
using App.Domain.AppService.Core_App.TransactionAggrigate;
using App.Domain.AppService.Core_App.UserAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.CardAggrigate.Repository;
using App.Domain.Core.Core_App.CardAggrigate.Services;
using App.Domain.Core.Core_App.TransactionAggrigate.AppService;
using App.Domain.Core.Core_App.TransactionAggrigate.Data.Repository;
using App.Domain.Core.Core_App.TransactionAggrigate.Services;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.Data.Repository;
using App.Domain.Core.Core_App.UserAggrigate.Services;
using App.Domain.Service.Core_App.CardAggrigate;
using App.Domain.Service.Core_App.TransactionAggrigate;
using App.Domain.Service.Core_App.UserAggrigate;
using App.Infra.Data.Repos.Ef.Core_App.TransactionAggrigate;
using App.Infra.Data.Repos.Ef.Core_App.UserAggrigate;
using App.Infra.DataAccess.Dapper.Core_App.CardAggrigate;

namespace App.EndPoints.MVC.Core_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserAppService, UserAppService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICardService, CardService>();
            builder.Services.AddScoped<ICardAppService, CardAppService>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=ChooseAction}/{id?}");

            app.Run();
        }
    }
}
