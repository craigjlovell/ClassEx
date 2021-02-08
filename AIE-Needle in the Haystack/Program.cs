using System;

namespace AIE_Needle_in_the_Haystack
{
    class Program
    {
        static int FindNeedle(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "needle")
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
                                  //     0      1       2      3      4           5           6  
            var strings = new string[] { "hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk" };

            

            int needleLocation = FindNeedle(strings);

            if(needleLocation < 0)
            {
                Console.WriteLine($"Needle was not found");
            }
            else
            {
                Console.WriteLine($"found the needle at {needleLocation}");
            }
           
        }
    }
}
