using System;
using System.Collections.Generic;

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
                for (int i = 0; i < inputArray.Length; i++)
                {
                    int val = inputArray[i];
                    if (val == 0)
                    {
                        int rowIndex = i / 9;
                        int columnIndex = i % 9;
                        List<int> rowKnownValues = new List<int>();
                        List<int> columnKnownValues = new List<int>();
                        List<int> squareKnownValues = new List<int>();

                        for (int j = rowIndex * 9; j < rowIndex * 10; j++)
                        {
                            if (inputArray[j] != 0)
                            {
                                rowKnownValues.Add(inputArray[j]);
                            }
                        }

                        for (int j = columnIndex; j < columnIndex + 72; j += 9)
                        {
                            if (inputArray[j] != 0)
                            {
                                columnKnownValues.Add(inputArray[j]);
                            }
                        }

                        int squareRowIndex = rowIndex / 3;
                        int squareColumnIndex = columnIndex / 3;

                        for (int j = squareRowIndex * 3; j < squareRowIndex * 3 + 3; j++)
                        {
                            for (int k = squareColumnIndex * 3; k < squareColumnIndex * 3 + 3; k++)
                            {
                                int cellIndex = j * 9 + k;
                                if (inputArray[cellIndex] != 0)
                                {
                                    squareKnownValues.Add(inputArray[cellIndex]);
                                }
                            }
                        }

                        inputArray[i] = Decide(rowKnownValues, columnKnownValues, squareKnownValues);
                    }
                }
            }
        }

        private static int Decide(List<int> rowKnownValues, List<int> columnKnownValues, List<int> squareKnownValues)
        {
            List<int> allPossibleValues = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                allPossibleValues.Add(i);
            }
            List<int> rowPossibleValues = ListComplement(rowKnownValues, allPossibleValues);
            List<int> columnPossibleValues = ListComplement(columnKnownValues, allPossibleValues);
            List<int> squarePossibleValues = ListComplement(squareKnownValues, allPossibleValues);
            List<int> totalIntersection = 
                ListIntersection(rowPossibleValues, ListIntersection(columnPossibleValues, squarePossibleValues));
            if (totalIntersection.Count == 1)
            {
                return totalIntersection[0];
            }
            else
            {
                return 0;
            }
        }

        private static List<int> ListIntersection(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list2.Count; i++)
            {
                if (list1.Contains(list2[i]))
                {
                    result.Add(list2[i]);
                }
            }
            return result;
        }

        private static List<int> ListComplement(List<int> list1, List<int> list2)
        {
            for (int i = 0; i < list2.Count; i++)
            {
                if (list1.Contains(list2[i]))
                {
                    list2.Remove(list2[i]);
                }
            }
            return list2;
        }

        private static int[] GetInputs()
        {
            Console.WriteLine("Input:");
            string inputString = "";

            while (inputString.Length != 81)
            {
                inputString = Console.ReadLine();
                if (inputString.Length != 81)
                {
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
