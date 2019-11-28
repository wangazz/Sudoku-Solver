using System;

namespace Sudoku_Solver
{
    class Program
    {
        static void Main()
        {
            int[] inputArray = GetInputs();
            int unknownSquares = UnknownSquares(inputArray);
            while (unknownSquares > 0)
            {
                foreach(int i in inputArray)
                {
                    if (inputArray[i] == 0) 
                    {
                        int rowIndex = i / 9;
                        int columnIndex = i % 9;
                        int[] rowArray;
                        int[] columnArray;
                        int[] squareArray;

                        for (int j = i - columnIndex; j < i - columnIndex + 9; j++)
                        {
                            if (inputArray[j] != 0)
                            {
                                // push value to rowArray
                            }
                        }

                        for (int j = columnIndex; j < columnIndex + 72; j += 9)
                        {
                            if (inputArray[j] != 0)
                            {
                                // push value to columnArray
                            }
                        }

                        for (something)
                        {
                            if (inputArray[j] != 0)
                            {
                                // push value to squareArray
                            }
                        }

                        // compare arrays here

                        inputArray[i] = Decide(rowArray, columnArray, squareArray);
                    }
                }
            }
        }

        private static int Decide(int[] rowArray, int[] columnArray, int[] squareArray)
        {
            if (single intersection of possible values)
            {
                return intersection;
            }
            else
            {
                return 0;
            }
        }

        private static int[] GetInputs()
        {
            Console.WriteLine("Input:");
            string inputString = "";

            while (inputString.Length != 81) {
                inputString = Console.ReadLine();
                if (inputString.Length != 81) {
                    Console.WriteLine("Invalid input.");
                }
            }

            int[] inputArray = new int[81];   

            for (int i = 0; i < 81; i++)
            {
                if (inputString[i] != '.')
                {
                    inputArray[i] = inputString[i];
                }
                else
                {
                    inputArray[i] = 0;
                }
            }

            return inputArray;
        }

        private static int UnknownSquares(int[] inputArray)
        {
            int knownSquares = 0;
            foreach (int i in inputArray)
            {
                if (i > 0)
                {
                    knownSquares++;
                }
            }
            return 81 - knownSquares;
        }
    }
}
