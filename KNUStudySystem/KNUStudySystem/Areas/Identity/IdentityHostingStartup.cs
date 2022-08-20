using System;
using KNUStudySystem.Areas.Identity.Data;
using KNUStudySystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(KNUStudySystem.Areas.Identity.IdentityHostingStartup))]
namespace KNUStudySystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StudySystemDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("MySqlConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<StudySystemDbContext>();
            });
        }
    }
}