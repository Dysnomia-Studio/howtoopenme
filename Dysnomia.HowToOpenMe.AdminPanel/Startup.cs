using Dysnomia.HowToOpenMe.Business.Implementations;
using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common;
using Dysnomia.HowToOpenMe.DataAccess.Implementations;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dysnomia.HowToOpenMe.AdminPanel {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			services.AddTransient<IAliasDataAccess, AliasDataAccess>();
			services.AddTransient<IExtensionDataAccess, ExtensionDataAccess>();
			services.AddTransient<IExtToSoftDataAccess, ExtToSoftDataAccess>();
			services.AddTransient<ISoftwareDataAccess, SoftwareDataAccess>();


			services.AddTransient<IAliasService, AliasService>();
			services.AddTransient<IExtensionService, ExtensionService>();
			services.AddTransient<IExtToSoftService, ExtToSoftService>();
			services.AddTransient<ISoftwareService, SoftwareService>();

			services.AddControllersWithViews();
			services.AddDistributedMemoryCache();
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSession();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
