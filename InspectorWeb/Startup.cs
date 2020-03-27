﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DevExpress.AspNetCore;
using InspectorWeb.Classes;
using InspectorWeb.Classes.Metadata;
using InspectorWeb.ViewModels;
using InspectorWeb.ModelsDB;

namespace InspectorWeb
{
	public class Startup
	{
		private const string DefaultConnectionStringName = "DefaultConnection";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			string defaultConnectionString = Configuration.GetConnectionString(DefaultConnectionStringName);

			services.AddDevExpressControls();
			//services.AddDbContext<InspectorWebDBContext>();
			services.AddDbContextPool<InspectorWebDBContext>(options => options.UseSqlServer(defaultConnectionString));

			services.AddMvc(options =>
			{
				options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((v) => $"Требуется указать значение");
			});

			//services.AddMvcCore(options =>
			//{
			//	options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((v) => $"Требуется указать значение");
			//})
			//.AddJsonFormatters();

			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfile());
			});

			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			//services.AddCors();			
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
	}
}