using System.Collections.Generic;
using System.Linq;

public class Element
{
    public List<int> rowKnownValues = new List<int>();
    public List<int> columnKnownValues = new List<int>();
    public List<int> boxKnownValues = new List<int>();
    public int rowIndex;
    public int columnIndex;
    public int boxRowIndex;
    public int boxColumnIndex;

    public Element(SudokuGrid grid, int index)
    {
        int value = grid.inputArray[index];
        rowIndex = index / 9;
        columnIndex = index % 9;
        boxRowIndex = rowIndex / 3;
        boxColumnIndex = columnIndex / 3;

        for (int j = rowIndex * 9; j < rowIndex * 9 + 9; j++)
        {
            if (grid.inputArray[j] != 0)
            {
                rowKnownValues.Add(grid.inputArray[j]);
            }
        }

        for (int j = columnIndex; j <= columnIndex + 72; j += 9)
        {
            if (grid.inputArray[j] != 0)
            {
                columnKnownValues.Add(grid.inputArray[j]);
            }
        }

        for (int j = boxRowIndex * 3; j < boxRowIndex * 3 + 3; j++)
        {
            for (int k = boxColumnIndex * 3; k < boxColumnIndex * 3 + 3; k++)
            {
                int cellIndex = j * 9 + k;
                if (grid.inputArray[cellIndex] != 0)
                {
                    boxKnownValues.Add(grid.inputArray[cellIndex]);
                }
            }
        }
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
