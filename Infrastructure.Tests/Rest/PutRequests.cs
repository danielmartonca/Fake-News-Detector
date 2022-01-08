using System;
using System.Net.Http;
using System.Net.Http.Json;
using Domain.Entities;
using Xunit;

namespace Infrastructure.Tests.Rest
{
    public class PutRequests
    {
        [Fact]
        public void CreateAccount(){
            using (var client = new HttpClient())
            {
                User u = new User();
                u.Username = "User";
                u.Email = "user@gmail.com";
                u.Password = "Pass";
                client.BaseAddress = new Uri("http://localhost:5001/");
                var response = client.PutAsJsonAsync("api/1/User/create", u).Result;
                Assert.True(response.IsSuccessStatusCode);
            }
        }
    }
}
