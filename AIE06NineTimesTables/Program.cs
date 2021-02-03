using System;

namespace AIE06NineTimesTables
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i < 11; i++)
            {
                sum = i * 9;
                Console.WriteLine($"The sum is {sum}");
            }


        }
    }
}
