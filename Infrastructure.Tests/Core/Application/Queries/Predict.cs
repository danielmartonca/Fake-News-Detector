using System;
using Xunit;
using Application.Features.Commands;
using MediatR;
using Domain.Entities;
using Moq;

namespace Infrastructure.Tests.Core.Application.Queries
{
    public class Predict
    {
        [Fact]
        public void PredictNewsNow()
        {
            var news = new News("Test2", "Test2", "Test2", DateTime.Today);
            var mediator = new Mock<Mediator>();
            var result = new PredictQuery(news);
            Assert.Equal("False", (System.Collections.Generic.IEnumerable<char>)result);
        }
    }
}
