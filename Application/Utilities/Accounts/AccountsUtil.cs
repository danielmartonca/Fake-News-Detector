using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Utilities.Accounts
{
    public class AccountsUtil
    {
        private static ILogger<string> _logger;

        public AccountsUtil(ILogger<string> logger)
        {
            _logger = logger;
        }

        private static bool CheckForNullValues(User user)
        {
            if (user == null) { _logger.LogError($"User is null for json: {user}"); return false; }
            if (user.Username == null) { _logger.LogError($"Username is null for json: {user}"); return false; }
            if (user.Password == null) { _logger.LogError($"Password is null for json: {user}"); return false; }
            if (user.Email == null) { _logger.LogError($"Email is null for json: {user}"); return false; }

            return true;
        }

        public static bool ValidateUserCredentials(User user)
        {
            if (CheckForNullValues(user) == false) return false;
            //TODO add other checks to see if data is ok
            return true;
        }
        public static Guid GenerateSessionId()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
    }
}
