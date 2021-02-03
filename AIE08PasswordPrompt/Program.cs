using System;

namespace AIE08PasswordPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            String pass = "";
            String passmatch = "";
            do
            {
                Console.WriteLine($"Enter Password");
                pass = Console.ReadLine();

                Console.WriteLine($"Confirm a password");
                passmatch = Console.ReadLine();

            } while (pass != passmatch);

            Console.WriteLine("Your password was confirmed");
            Console.WriteLine("Exiting");
        }
    }
}
