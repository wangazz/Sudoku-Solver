using System;

namespace Sudoku_Solver
{
    class Solver
    {
        static void Main()
        {
            SudokuGrid grid = new SudokuGrid();
            while (grid.UnknownSquares > 0)
            {
                for (int i = 0; i < grid.inputArray.Length; i++)
                {
                    if (grid.inputArray[i] == 0)
                    {
                        grid.inputArray[i] = new Element(grid, i).Decide();
                    }
                }
            }
            PrintOutput(grid.inputArray);
        }

        private static void PrintOutput(int[] input)
        {
            string outputString = "";
            foreach (int i in input)
            {
                outputString += i.ToString();
            }
            Console.WriteLine(outputString);
        }
    }
}
