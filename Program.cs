/* 
 * Sadie Pretzlaff
 * CMPE 1666
 * ICA01
 * September 9, 2025
 */


using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_SadieP
{
    internal class Program
    {
        static Random Rand = new Random();

        static void Main(string[] args)
        {
            int[] array; //the array that holdds the generated values
            int arraySize;//the size of the array to becreated
            int searchValue; //the value that the program searches the array for
            bool success = false; //flag that is set when the user inputs a valid input and is used to control the loop
            bool done = false; //flag setwehn the user is done using the program to exit the main loop
            string title = "CMPE 1666 - ICA01 Fall 2025 - Sadie Pretzlaff";

            //center cursor position and display title block
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title + "\n");

            //get the array size from the user
            arraySize = GetValue("\nInput the size of the array to generate", 10, 100); 

            //get the range of values from the user
            GetRange(out int min, out int max);

            //create and fill the array
            array = GenerateArray(arraySize, min, max);

            //display the array
            DisplayArray(array);

            //the loop that searches the array for a value
            do
            {
                //gets the value to be searched for
                Console.Write("\nEnter Value to be searched: ");
                success = int.TryParse(Console.ReadLine(), out searchValue);

                //checks that the value is valid and in range, if not it restarts the loop
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
                    //counts the occurences of the value being searched and displays the resule
                    int count = CountOccurences(array, searchValue);
                    if (count != 0)
                    {
                        Console.WriteLine($"\nNumber of occurences of {searchValue} is {count}");
                    }
                    else
                    {
                        Console.WriteLine($"\n{searchValue} is not found in array.");
                    }

                    //asks the user if they want to search another number, and exits the main loop if they don't
                    do
                    {
                        //gets the user input
                        Console.Write("\nDo you want to search for another value? (Y/N, y/n) : ");
                        string searchAgain = Console.ReadLine();

                        //validates the user input and sets the flags for the loops
                        if (searchAgain == "n" || searchAgain == "N")
                        {
                            //sets the flags so the user exits this looop and the main loop
                            done = true;
                            success = true;
                        }
                        else if (searchAgain == "y" || searchAgain == "Y")
                        {
                            //sets the flags so the user exits this loop but not the main loop
                            success = true;
                        }
                        else
                        {
                            //sets the flags so the user doesn't exit this loop
                            success = false;
                            Console.WriteLine("\nPlease respond with Y,y,N, or n.");
                        }
                    } while (!success);
                }
            } while (!done);
        }

        //displays the passed array in the terminal
        static void DisplayArray(int[] array)
        {
            Console.Write("\nThe Generrated values are: ");
            
            //adds ach value in the array to the curent line of the terminal
            foreach(int i in array)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("\n");
        }

        //counts how often a given value appears in the array
        static int CountOccurences(int[] array, int value)
        {
            int count = 0;

            //goes trhough all the array values and compares them to the given value, increasing the count for each occurence
            foreach(int i in array)
            {
                if (i == value)
                {
                    count++;
                }
            }
            return count;
        }

        //generates a random array of a specifiesd size with values bounded by min and max
        static int[] GenerateArray(int size, int min, int max)
        {
            int[] array = new int[size];

            //generates a random value and assigns it to each index of the array
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Rand.Next(min, max);
            }
            return array;
        }

        //gets a range of values from the user
        static void GetRange(out int min, out int max)
        {
            //gets the min nad max values, if the min is greater than the max, it informs the user and restarts the process
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

        //returns an integer value from the user, ensuring that it's valid and within the specified range
        static int GetValue(string message, int min, int max)
        {
            bool success = false; //controls the loop by allowing the program to exit only if it is set
            int value = 0; //the value received by the user

            do
            {
                //gets the value from the user
                Console.Write($"{message} ({min}-{max}): ");
                success = int.TryParse(Console.ReadLine(), out value);

                //informs the user if the value is invalid
                if (!success)
                {
                    Console.WriteLine("\nError: Value invalid. Please try again.\n");
                }
                else if (value < min || value > max)
                {
                    //resets the success flag if the value inputted by the user is out of range, so that the loop executes itself again instead of exiting
                    success = false;
                    Console.WriteLine($"\nError: Value out of range. Please input a value between {min} and {max}.\n");
                }
            } while (!success);

            return value;
        }
    }
}
