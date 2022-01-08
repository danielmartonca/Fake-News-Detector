using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Application.Utilities
{
    class HashingUtil
    {
        //private static ILogger<string> _logger;

        private const string SALT_PATH = "../Application\\Utilities\\Hashing\\Salt.txt";
        private const int SALT_SIZE = 128 / 8;

        private static readonly byte[] salt = new byte[SALT_SIZE];

        private static void ImportSalt()
        {
            foreach (var bit in salt)
                if (bit != 0)
                    return;

            if (ImportSaltFromFile() == false)
            {
                CrateNewSalt();
                WriteSaltToFile(salt);
            }
        }
        private static void CrateNewSalt()
        {
            using var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetNonZeroBytes(salt);
        }
        private static void WriteSaltToFile(byte[] salt)
        {
            try
            {
                using FileStream fs = File.Open(SALT_PATH, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                fs.Write(salt, 0, salt.Length);
                fs.Close();
                //_logger.LogDebug("Created new salt. All accounts need to be reseted.");
            }
            catch (IOException)
            {
                // _logger.LogError("Failed to create new salt.");
            }
        }
        private static bool ImportSaltFromFile()
        {
            try
            {
                using FileStream fs = File.Open(SALT_PATH, FileMode.Open, FileAccess.Read, FileShare.None);
                fs.Read(salt, 0, salt.Length);
                fs.Close();

                foreach (var bit in salt)
                    if (bit != 0)
                        return true;

                //_logger.LogDebug("Found salt but it was set to 0. Creating new one.");
                return false;
            }
            catch (IOException)
            {
                //_logger.LogError("Failed to import salt file. Creating new one.");
                return false;
            }
        }
        public static string GetHash(string text)
        {
            ImportSalt();
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            //_logger.LogDebug($"Hashed text to: {hashed}");

            return hashed;
        }
    }
}
