using System.Net;
using System.Net.Http;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

using Xunit;

namespace Dysnomia.HowToOpenMe.AdminPanel.Tests {
	public class AliasController {
		public HttpClient client { get; }
		public TestServer server { get; }

		public AliasController() {
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
			var response = await client.GetAsync("/Alias/");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Fact]
		public async void ShouldGet500_GET_Details_Empty() {
			var response = await client.GetAsync("/Alias/Details");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Fact]
		public async void ShouldGet200_GET_Details() {
			var response = await client.GetAsync("/Alias/Details/1");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Fact]
		public async void ShouldGet200_GET_Create() {
			var response = await client.GetAsync("/Alias/Create");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Create

		[Fact]
		public async void ShouldGet500_GET_Edit_Empty() {
			var response = await client.GetAsync("/Alias/Edit");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Fact]
		public async void ShouldGet200_GET_Edit() {
			var response = await client.GetAsync("/Alias/Edit/1");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Edit

		[Fact]
		public async void ShouldGet500_GET_Delete_Empty() {
			var response = await client.GetAsync("/Alias/Delete");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Fact]
		public async void ShouldGet200_GET_Delete() {
			var response = await client.GetAsync("/Alias/Delete/1");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Delete
	}
}