using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ArrayGenerator
{
	/// <summary>
	/// Boilerplate program to start web host
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
