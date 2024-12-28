namespace Waffle_API.Classes
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography;

    public class HashController
    {
        private readonly PasswordHasher<string> _stringHasher;
        public HashController()
        {
            _stringHasher = new PasswordHasher<string>();
        }

        // Hash a password
        public string HashString(string stringToHash)
        {
            string salt = GenerateSalt();
            string hashedString = _stringHasher.HashPassword(salt, stringToHash);
            return $"{salt}:{hashedString}";
        }

        // Verify a password
        public bool VerifyString(string hashedString, string inputString)
        {
            string[] parts = hashedString.Split(':');

            if (parts.Length != 2)
            {
                return false;
            }

            var result = _stringHasher.VerifyHashedPassword(parts[0], parts[1], inputString);
            return result == PasswordVerificationResult.Success;
        }

        public static string GenerateSalt()
        {
            byte[] salt = new byte[32]; // 16 bytes = 128 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
