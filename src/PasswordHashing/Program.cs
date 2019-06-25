using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashing
{
    class Program
    {
        static void Main(string[] args)
        {

            var hasher = new PasswordHasher();
            var password = "mypassword";
            var hash = hasher.Generate(password, 975);

            Console.WriteLine("Hashed text for {0} is {1}", password, hash);

            string[] testPasswords = { "not it", "mypassword", "notitagain" };

            foreach (var testPassword in testPasswords)
                Console.WriteLine("Password '{0}' {1} valid", testPassword, hasher.IsValid(testPassword,hash)? "is" : "is not");


            Console.ReadKey();


    

        }

       


    }
}
