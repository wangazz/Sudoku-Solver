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
            while (grid.UnknownSquares() > 0)
            {
                for (int i = 0; i < grid.inputArray.Length; i++)
                {
                    if (grid.inputArray[i] == 0)
                    {
                        Subspace subspace = new Subspace(i, grid.inputArray[i]);

                        for (int j = subspace.rowIndex * 9; j < subspace.rowIndex * 9 + 9; j++)
                        {
                            if (grid.inputArray[j] != 0)
                            {
                                subspace.rowKnownValues.Add(grid.inputArray[j]);
                            }
                        }

                        for (int j = subspace.columnIndex; j <= subspace.columnIndex + 72; j += 9)
                        {
                            if (grid.inputArray[j] != 0)
                            {
                                subspace.columnKnownValues.Add(grid.inputArray[j]);
                            }
                        }

                        for (int j = subspace.boxRowIndex * 3; j < subspace.boxRowIndex * 3 + 3; j++)
                        {
                            for (int k = subspace.boxColumnIndex * 3; k < subspace.boxColumnIndex * 3 + 3; k++)
                            {
                                int cellIndex = j * 9 + k;
                                if (grid.inputArray[cellIndex] != 0)
                                {
                                    subspace.boxKnownValues.Add(grid.inputArray[cellIndex]);
                                }
                            }
                        }

                        grid.inputArray[i] = Decide(subspace);
                    }
                }
            }
            PrintOutput(grid.inputArray);
        }

        private static int Decide(Subspace subspace)
        {
            List<int> rowPossibleValues = SubspaceComplement(subspace.rowKnownValues);
            List<int> columnPossibleValues = SubspaceComplement(subspace.columnKnownValues);
            List<int> squarePossibleValues = SubspaceComplement(subspace.boxKnownValues);

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

        private static List<int> SubspaceComplement(List<int> list1)
        {
            List<int> fullSubspace = Subspace.fullSubspace;
            List<int> result = new List<int>();
            for (int i = 0; i < fullSubspace.Count; i++)
            {
                int listItem = fullSubspace[i];
                if (list1.Contains(listItem) == false)
                {
                    result.Add(listItem);
                }
            }
            return result;
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
