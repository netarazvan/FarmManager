using System;
using FarmManager.Areas.Identity.Data;
using FarmManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FarmManager.Areas.Identity.IdentityHostingStartup))]
namespace FarmManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FarmManagerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FarmManagerContextConnection")));

                services.AddDefaultIdentity<FarmManagerUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FarmManagerContext>();
            });
        }
    }
}