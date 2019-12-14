using System.Net;
using System.Net.Http;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

using Xunit;


namespace Dysnomia.HowToOpenMe.AdminPanel.Tests {
	public class ExtToSoftController {
		public HttpClient client { get; }
		public TestServer server { get; }

		public ExtToSoftController() {
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false)
				.Build();

			var builder = new WebHostBuilder()
				 .UseConfiguration(config)
				.UseStartup<Startup>()
				.UseEnvironment("Testing");
			var server = new TestServer(builder);

			client = server.CreateClient();
		}

		[Fact]
		public async void ShouldGet200_GET_Index() {
			var response = await client.GetAsync("/Softwares/");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}
	}
}
