using System;

namespace temp2
{
    class Program
    {
        static void Main(string[] args)
        {
            float celcius = 24;

            //Divide by 5, the multiply by 9, then add 32 
            float celciusToFarenheight = celcius / 5.0f * 9.0f + 32.0f;

            Console.WriteLine($"{celcius} Celsius is {celciusToFarenheight} Fahrenheit");

            // Deduct 32, the multiply by 5, then divide by 9.
            float farenheightToCelcus = (celciusToFarenheight - 32) * 5.0f / 9.0f;

            Console.WriteLine($"{celciusToFarenheight} Fahrenheit is {farenheightToCelcus} Celsius");
        }
    }
}
