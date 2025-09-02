using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_SadieP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetRange(out int min, out int max);
        }
        static void GetRange(out int min, out int max)
        {
            Console.WriteLine("Input the minimum value.");
            min = GetValue(1, 2);
            max = GetValue(1, 2);
        }
        static int GetValue(int min, int max)
        {
            bool success = false;
            int value = 0;
            do
            {
                Console.Write($"Please input an int between {min} and {max}: ");
                success = int.TryParse(Console.ReadLine(), out value);
                if (!success)
                {
                    Console.WriteLine("Error: Value invalid. Please try again.\n");
                }
            } while (!success);


            return value;
        }
    }
}
