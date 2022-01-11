using Application.Features.Commands.UserCommands;
using Domain.Entities;
using MediatR;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Core.Application.Commands

{
    public class Create
    {
        [Fact]
        public void CreateCommand()
        {
            User user = new User();
            user.Username = "Test";
            user.Password = "Password";
            user.Email = "Email";
            var mediator = new Mock<IMediator>();
            CreateUserCommand cuc = new CreateUserCommand { Username = user.Username, Password = user.Password, Email = user.Email };
            Assert.Equal("Application.Features.Commands.UserCommands.CreateUserCommand", cuc.ToString());
        }
    }
}
