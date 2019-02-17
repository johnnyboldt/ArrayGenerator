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

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
