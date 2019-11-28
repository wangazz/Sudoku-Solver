using System;

namespace Sudoku_Solver
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input:");
            string inputString = "";
            while (inputString.Length != 81) {
                inputString = Console.ReadLine();
                if (inputString.Length != 81) {
                    Console.WriteLine("Invalid input.");
                }
            }
            ProcessInputs(inputString);
        }

        private static void ProcessInputs(string inputString)
        {
            int[] inputArray = new int[81];
            
        }
    }
}
