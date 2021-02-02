using System;

namespace AIE04Temp
{
    class Program
    {
        static void Main(string[] args)
        {

            string tempcString = Console.ReadLine();
            int c = int.Parse(tempcString);
            int v = 5;
            int x = 9;
            int z = 32;

            int f = (c / v * x + z);
            Console.WriteLine(f);

        }
    }
}
