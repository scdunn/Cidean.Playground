using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashing
{
    public class PasswordHasher
    {
        /// <summary>
        /// Return a string delimited with random salt, #iterations and hashed password
        /// can be store in database for validation.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public string Generate(string password, int iterations = 1000)
        {
            //generate a random salt for hashing
            var salt = new byte[24];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //hash password given salt and iterations (default to 1000)
            //iterations provide difficulty when cracking
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(24);
            
            //return delimited string with salt | #iterations | hash
            return Convert.ToBase64String(salt) + "|" + iterations + "|" +
                Convert.ToBase64String(hash);
            
        }

        /// <summary>
        /// Returns true of hash of test password matches hashed password within origDelimHash
        /// </summary>
        /// <param name="testPassword"></param>
        /// <param name="origDelimHash"></param>
        /// <returns></returns>
        public bool IsValid(string testPassword, string origDelimHash)
        {
            //extract original values from delimited hash text
            var origHashedParts = origDelimHash.Split('|');
            var origSalt = Convert.FromBase64String(origHashedParts[0]);
            var origIterations = Int32.Parse(origHashedParts[1]);
            var origHash = origHashedParts[2];

            //generate hash from test password and original salt and iterations
            var pbkdf2 = new Rfc2898DeriveBytes(testPassword, origSalt, origIterations);
            byte[] testHash = pbkdf2.GetBytes(24);
            
            //if hash values match then return success
            if (Convert.ToBase64String(testHash) == origHash)
                return true;
            
            //no match return false
            return false;

        }
    }
}
