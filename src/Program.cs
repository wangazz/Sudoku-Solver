using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku_Solver
{
    class Program
    {
        static void Main()
        {
            SudokuGrid grid = new SudokuGrid();
            int[] inputArray = grid.inputArray;
            int unknownSquares = grid.UnknownSquares(inputArray);
            while (unknownSquares > 0)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i] == 0)
                    {
                        int rowIndex = i / 9;
                        int columnIndex = i % 9;
                        List<int> rowKnownValues = new List<int>();
                        List<int> columnKnownValues = new List<int>();
                        List<int> squareKnownValues = new List<int>();

                        for (int j = rowIndex * 9; j < rowIndex * 9 + 9; j++)
                        {
                            if (inputArray[j] != 0)
                            {
                                rowKnownValues.Add(inputArray[j]);
                            }
                        }

                        for (int j = columnIndex; j <= columnIndex + 72; j += 9)
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
                        unknownSquares = grid.UnknownSquares(inputArray);
                    }
                }
            }
            PrintOutput(inputArray);
        }

        private static int Decide(List<int> rowKnownValues, List<int> columnKnownValues, List<int> squareKnownValues)
        {
            List<int> allPossibleValues = Subspace.AllPossibleValues();
            List<int> rowPossibleValues = ListComplement(rowKnownValues, allPossibleValues);
            List<int> columnPossibleValues = ListComplement(columnKnownValues, allPossibleValues);
            List<int> squarePossibleValues = ListComplement(squareKnownValues, allPossibleValues);

            List<int> totalIntersection = rowPossibleValues.Intersect(columnPossibleValues.Intersect(squarePossibleValues)).ToList();
            if (totalIntersection.Count == 1)
            {
                return totalIntersection[0];
            }
            else
            {
                return 0;
            }
        }

        private static List<int> ListComplement(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list2.Count; i++)
            {
                int listItem = list2[i];
                if (list1.Contains(listItem) == false)
                {
                    result.Add(listItem);
                }
            }
            return result;
        }

        private static void PrintOutput(int[] inputArray)
        {
            string outputString = "";
            foreach (int i in inputArray)
            {
                outputString += i.ToString();
            }
            Console.WriteLine(outputString);
        }
    }
}
