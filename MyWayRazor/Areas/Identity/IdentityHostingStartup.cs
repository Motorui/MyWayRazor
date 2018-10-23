﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWayRazor.Areas.Identity.Data;
using MyWayRazor.Data;

[assembly: HostingStartup(typeof(MyWayRazor.Areas.Identity.IdentityHostingStartup))]
namespace MyWayRazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<MyWayUser>()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}