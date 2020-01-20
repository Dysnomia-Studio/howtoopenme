using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Dysnomia.HowToOpenMe.Common.Models;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

using Xunit;

namespace Dysnomia.HowToOpenMe.AdminPanel.Tests {
	public class SelectAllController {
		public HttpClient client { get; }
		public TestServer server { get; }

		public SelectAllController() {
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
		public async void ShouldGet200_GET_Extensions() {
			var response = await client.GetAsync("/api/SelectAll/extension");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsAsync<IEnumerable<Extension>>();

			content.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public async void ShouldGet200_GET_Softwares() {
			var response = await client.GetAsync("/api/SelectAll/software");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsAsync<IEnumerable<Software>>();

			content.Should().NotBeNullOrEmpty();
		}
	}
}
