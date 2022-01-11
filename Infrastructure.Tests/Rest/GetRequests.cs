using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Rest
{
    public class GetRequests
    {
        [Fact]
        public async Task GettingNewsFromHttpGetVerbeWhenCheckEmptinessThenObtainResult()
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync("https://localhost:5001/api/1/News?id=0e937846-8bd4-49eb-94bd-029fbcb725d8");
            Assert.NotEmpty(content);
        }
    }
}
