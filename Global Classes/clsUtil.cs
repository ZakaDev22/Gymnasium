using System;
using System.Security.Cryptography;
using System.Text;

namespace Gymnasium.Global_Classes
{
    public class clsUtil
    {
        /// <summary>
        /// Computes the SHA-256 hash value of the input string and returns it as a lowercase hexadecimal string.
        /// </summary>
        /// <param name="input">The input string to be hashed.</param>
        /// <returns>The SHA-256 hash value of the input string as a lowercase hexadecimal string.</returns>
        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }

        }
    }
}
