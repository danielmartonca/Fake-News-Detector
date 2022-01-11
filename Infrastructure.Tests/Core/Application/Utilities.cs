using Domain.Entities;
using Xunit;
using Application.Utilities.Accounts;


namespace Infrastructure.Tests.Core
{
    public class Utilities
    {
        [Fact] 
        public void GivenUserCredentialsWhenCheckValidityThenObtainTrue()
        {
            var user = new User();
            user.Username = "test";
            user.Password = "testpass";
            user.Email = "test@gmail.com";
            bool result = AccountsUtil.ValidateUserCredentials(user);
            Assert.True(result);
        }
    }
}