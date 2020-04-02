using System;
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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfile());
			});

			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				options.Cookie.Name = "UserLoginCookie";
				options.LoginPath = "/Account/Login";

				//options.ExpireTimeSpan = TimeSpan.FromDays(1);
				//options.SlidingExpiration = true;
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.  
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
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

			//app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseAuthentication();
			//app.UseSession();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "DocsExaminationTasks", action = "Index" });


				routes.MapRoute(
					name: "data",
					template: "api/data/{controller}");
			});
		}
	}
}