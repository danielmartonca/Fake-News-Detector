using System;
using Xunit;
using Application.Features.Commands;
using Domain.Entities;
namespace Infrastructure.Tests
{
    public class Predict
    {
        [Fact]
        public void TestMethodFalse()
        {
            var sampleData = new News("Test","Test","Test",DateTime.Today);
            var pq = new PredictQuery(sampleData);
           // var result = 
// Assert.Equal("Fake", result);
        }
        [Fact]
        public void TestMethodTrue()
        {
            var sampleData = new News("Test2", "Test2", "Test2", DateTime.Today);
            var pq = new PredictQuery(sampleData);
            //  String result = Application.Features.Commands.PredictQuery.PredictNews(sampleData);
            //  Assert.Equal("Real", result);
        }
    }
}
