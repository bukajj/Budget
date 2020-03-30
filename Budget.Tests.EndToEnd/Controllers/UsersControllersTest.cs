using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Budget.Api;
using Budget.Infrastructure.Commands;
using Budget.Infrastructure.DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Budget.Tests.EndToEnd.Controllers
{
    public class UsersControllersTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public UsersControllersTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var response = await _client.GetAsync($"{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "user1000@email.com",
                Firstname = "Adam",
                Lastname = "Adamski",
                Passsword = "secret"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"{request.Email}");

        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}