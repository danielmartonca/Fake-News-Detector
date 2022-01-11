using System;
using Application.Features.Commands;
using Domain.Entities;
using MediatR;
using Xunit;
using Moq;

namespace Infrastructure.Tests.Core.Application.Queries
{
    public class QueryNews
    {
        [Fact]
        public void GivenNewsWhenCheckIfIsValidThenObtainResult()
        {
            var news = new News("Test2", "Test2", "Test2", DateTime.Today);
            var mediator = new Mock<IMediator>();
            CreateUserCommand cnc = new CreateUserCommand(news);
            Assert.Equal("Application.Features.Commands.CreateNewsCommand", cnc.ToString());

        }
    }
}
