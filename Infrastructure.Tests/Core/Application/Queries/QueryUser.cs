using System;
using Application.Features.Commands.UserCommands;
using Domain.Entities;
using MediatR;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Core.Application.Queries
{
    public class QueryUser
    {
        [Fact] 
        public void GivenUserSessionIdWhenCheckIfIsNullThenObtainResult()
        {
            var ses = new UserSession();
            var mediator = new Mock<Mediator>();
            var result = new DeleteSessionIdQuery(ses);
            Assert.Null(result.userSession.Username);
        }
    }
}
