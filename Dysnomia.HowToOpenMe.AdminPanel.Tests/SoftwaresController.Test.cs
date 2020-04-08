using System.Net;
using System.Net.Http;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

using Xunit;

namespace Dysnomia.HowToOpenMe.AdminPanel.Tests {
	public class SoftwaresController {
		public HttpClient client { get; }
		public TestServer server { get; }

		public SoftwaresController() {
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

		[Fact]
		public async void ShouldGet500_GET_Details_Empty() {
			var response = await client.GetAsync("/Softwares/Details");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Fact]
		public async void ShouldGet200_GET_Details() {
			var response = await client.GetAsync("/Softwares/Details/notepad");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Fact]
		public async void ShouldGet200_GET_Create() {
			var response = await client.GetAsync("/Softwares/Create");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Create

		/*[Fact]
		public async void ShouldGet500_GET_Edit_Empty() {
			var response = await client.GetAsync("/Softwares/Edit");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}*/

		[Fact]
		public async void ShouldGet200_GET_Edit() {
			var response = await client.GetAsync("/Softwares/Edit/notepad");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Edit

		/*[Fact]
		public async void ShouldGet500_GET_Delete_Empty() {
			var response = await client.GetAsync("/Softwares/Delete");

			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
		}*/

		[Fact]
		public async void ShouldGet200_GET_Delete() {
			var response = await client.GetAsync("/Softwares/Delete/notepad");

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		// TODO: POST /Delete
	}
}
