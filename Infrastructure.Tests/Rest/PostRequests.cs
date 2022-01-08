using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Rest
{
    public class PostRequests
    {
        [Fact]
        public async Task LoginValidateCredentials()
        {
            var values = new Dictionary<string, string>
{
    { "id", "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
    { "username", "User" },
    { "email", "user@gmail.com" },
    { "password", "pass" }
};

            var data = new FormUrlEncodedContent(values);

            var url = "https://localhost:5001/api/1/User/login";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

        }

        [Fact]
        public async Task VerifyInvalidSessionID()
        {
            var values = new Dictionary<string, string>
{
    { "id", "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
    { "username", "User2" },
    { "sessionId", "3fa85f64-5717-4562-b3fc-2c963f66afa5" }
};

            var data = new FormUrlEncodedContent(values);

            var url = "https://localhost:5001/api/1/User/sessionID";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Invalid session id", result);

        }
    [Fact]
    public async Task VerifyValidSessionID()
    {
        var values = new Dictionary<string, string>
{
    { "id", "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
    { "username", "User2" },
    { "sessionId", "3fa85f64-5717-4562-b3fc-2c963f66afa6" }
};

        var data = new FormUrlEncodedContent(values);

        var url = "https://localhost:5001/api/1/User/sessionID";
        using var client = new HttpClient();

        var response = await client.PostAsync(url, data);

        string result = response.Content.ReadAsStringAsync().Result;
        Assert.Equal("200", result);

    }
}
}
