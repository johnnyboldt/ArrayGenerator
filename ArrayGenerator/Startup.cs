using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace ArrayGenerator
{
	/// <summary>
	/// Boilerplate class to start service
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// The URL of the Front End
		/// Port should be 3000 (might vary on non-Windows environments)
		/// </summary>
		private const string WebAppUrl = "http://localhost:3000";
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var assemblyToScan = Assembly.GetAssembly(typeof(Startup));

			// Dependency Injection Setup
			//https://www.thereformedprogrammer.net/asp-net-core-fast-and-automatic-dependency-injection-setup/
			services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
				//.Where(c => c.Name.EndsWith("Service")) Only add this if we need to exclude certain classes from Dependency Injection
				.AsPublicImplementedInterfaces();
			services.AddCors(); // Enabled CORS https://stackoverflow.com/questions/44379560/how-to-enable-cors-in-asp-net-core-webapi
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseCors(
				options => options.WithOrigins(WebAppUrl).AllowAnyMethod()
			);
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
