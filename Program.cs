using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_SadieP
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int[] array;

            int arraySize;
            int searchValue;
            bool done = false;
            arraySize = GetValue("\nInput the size of the array to generate", 10, 100); 
            GetRange(out int min, out int max);
            array = GenerateArray(arraySize, min, max);
            DisplayArray(array);
            do
            {
                Console.Write("\nEnter Value to be searched: ");
                bool success = int.TryParse(Console.ReadLine(), out searchValue);
                if (!success)
                {
                    Console.WriteLine("\nValue invalid, please enter a integer number");
                }
                else if (searchValue < min || searchValue > max)
                {
                    Console.WriteLine("\nValue out of range, please enter another value");
                }
                else
                {
                    int count = CountOccurences(array, searchValue);
                    if (count != 0)
                    {
                        Console.WriteLine($"\nNumber of occurences of {searchValue} is {count}");
                    }
                    else
                    {
                        Console.WriteLine($"\n{searchValue} is not found in array.");
                    }

                    do
                    {
                        Console.Write("\nDo you want to search for another value? (Y/N, y/n) : ");
                        string searchAgain = Console.ReadLine();
                        if (searchAgain == "n" || searchAgain == "N")
                        {
                            done = true;
                            success = true;
                        }
                        else if (searchAgain == "y" || searchAgain == "Y")
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                            Console.WriteLine("\nPlease respond wiht Y,y,N, or n.");
                        }
                    } while (!success);
                }
            } while (!done);
        }

        static void DisplayArray(int[] array)
        {
            Console.Write("\nThe Generrated values are: ");
            foreach(int i in array)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("\n");
        }

        static int CountOccurences(int[] array, int value)
        {
            int count = 0;
            foreach(int i in array)
            {
                if (i == value)
                {
                    count++;
                }
            }
            return count;
        }

        static int[] GenerateArray(int size, int min, int max)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max);
            }
            return array;
        }

        static void GetRange(out int min, out int max)
        {
            do
            {
                min = GetValue("\nEnter the lower limit of values to be generated", 0, 100);
                max = GetValue("\nEnter the upper limit of values to be generated", 0, 100);
                if (!(min < max))
                {
                    Console.WriteLine("\nPlease ensure upper limit is greater than lower limit");
                }
            }
            while (!(min < max));
        }

        static int GetValue(string message, int min, int max)
        {
            bool success = false;
            int value = 0;
            do
            {
                Console.Write($"{message} ({min}-{max}): ");
                success = int.TryParse(Console.ReadLine(), out value);
                if (!success)
                {
                    Console.WriteLine("\nError: Value invalid. Please try again.\n");
                }
                else if (value < min || value > max)
                {
                    success = false;
                    Console.WriteLine($"\nError: Value out of range. Please input a value between {min} and {max}.\n");
                }
            } while (!success);


            return value;
        }
    }
}
