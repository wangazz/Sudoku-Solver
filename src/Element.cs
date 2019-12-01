using System.Collections.Generic;
using System.Linq;

public class Element
{
    private List<int> rowKnownValues = new List<int>();
    private List<int> columnKnownValues = new List<int>();
    private List<int> boxKnownValues = new List<int>();
    private int rowIndex;
    private int columnIndex;
    private int boxRowIndex;
    private int boxColumnIndex;

    public Element(SudokuGrid grid, int index)
    {
        int value = grid.inputArray[index];
        rowIndex = index / 9;
        columnIndex = index % 9;
        boxRowIndex = rowIndex / 3;
        boxColumnIndex = columnIndex / 3;

        for (int i = rowIndex * 9; i < rowIndex * 9 + 9; i++)
        {
            if (grid.inputArray[i] != 0)
            {
                rowKnownValues.Add(grid.inputArray[i]);
            }
        }

        for (int i = columnIndex; i <= columnIndex + 72; i += 9)
        {
            if (grid.inputArray[i] != 0)
            {
                columnKnownValues.Add(grid.inputArray[i]);
            }
        }

        for (int i = boxRowIndex * 3; i < boxRowIndex * 3 + 3; i++)
        {
            for (int j = boxColumnIndex * 3; j < boxColumnIndex * 3 + 3; j++)
            {
                int cellIndex = i * 9 + j;
                if (grid.inputArray[cellIndex] != 0)
                {
                    boxKnownValues.Add(grid.inputArray[cellIndex]);
                }
            }
        }
    }

    private List<int> Complement(List<int> input)
    {
        List<int> fullSubspace = FullSubspace();
        List<int> result = new List<int>();
        for (int i = 0; i < fullSubspace.Count; i++)
        {
            int listItem = fullSubspace[i];
            if (input.Contains(listItem) == false)
            {
                result.Add(listItem);
            }
        }
        return result;
    }

    public int Decide()
    {
        List<int> rowPossibleValues = Complement(rowKnownValues);
        List<int> columnPossibleValues = Complement(columnKnownValues);
        List<int> boxPossibleValues = Complement(boxKnownValues);

        List<int> totalIntersection = rowPossibleValues.Intersect(columnPossibleValues.Intersect(boxPossibleValues)).ToList();
        if (totalIntersection.Count == 1)
        {
            return totalIntersection[0];
        }
        else
        {
            return 0;
        }
    }

    private List<int> FullSubspace()
    {
        List<int> allPossibleValues = new List<int>();
        for (int i = 1; i <= 9; i++)
        {
            allPossibleValues.Add(i);
        }
        return allPossibleValues;
    }
}
