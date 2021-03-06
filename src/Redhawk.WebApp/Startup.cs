﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Redhawk.WebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Redhawk.WebApp.Models;

namespace Redhawk.WebApp
{
    public class Startup
    {
		public static IConfigurationRoot Configuration;

		public Startup(IApplicationEnvironment appEnv)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(appEnv.ApplicationBasePath)
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();

			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<RedhawkContext>();

			services.AddTransient<RedhawkContextSeedData>();

#if DEBUG
			services.AddScoped<IMailService, DebugMailService>();
#else
			services.AddScoped<IMailService, ReleaseMailService>();
#endif
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, RedhawkContextSeedData seeder)
        {
            //app.UseIISPlatformHandler();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

			app.UseStaticFiles();
			app.UseMvc(config =>
			{
				config.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "App", action = "Index" }
					);
			});

			seeder.EnsureSeedData();
		}

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
