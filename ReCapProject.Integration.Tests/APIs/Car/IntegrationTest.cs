using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI;
using WebAPI.Controllers;

namespace ReCapProject.Integration.Tests.APIs.Car
{
    public partial class IntegrationTest
    {
        private readonly HttpClient testClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder=>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(RantaCarContext));
                        services.AddDbContext<RantaCarContext>(option =>
                        {
                            option.UseSqlServer(@"Server=LAPTOP-OLL6HKD6\SQLEXPRESS;Database=ReCapDb;Trusted_Connection=True");
                        });
                    });
                });

            testClient = appFactory.CreateClient();
        }

        private void Authenticate()
        {
            testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await testClient.PostAsJsonAsync(CarsController., new UserForRegisterDto {
                Email = "test@integration.com",
                Password = "SomePass1234!"
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();
            return registrationResponse.Token;
        }
    }
}
