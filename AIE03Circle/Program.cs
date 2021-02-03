using System;

namespace AIE03Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = 8;
            double circumference = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("The circumference is " + circumference);
            Console.WriteLine("The area is " + area);

        }
    }
}
