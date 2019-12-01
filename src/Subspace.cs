using System.Collections.Generic;

public class Subspace
{
    public static List<int> fullSubspace = FullSubspace();
    public List<int> rowKnownValues = new List<int>();
    public List<int> columnKnownValues = new List<int>();
    public List<int> boxKnownValues = new List<int>();
    public int rowIndex;
    public int columnIndex;
    public int boxRowIndex;
    public int boxColumnIndex;

    public Subspace(int index, int value)
    {
        fullSubspace = FullSubspace();
        rowIndex = index / 9;
        columnIndex = index % 9;
        boxRowIndex = rowIndex / 3;
        boxColumnIndex = columnIndex / 3;
    }

    private static List<int> FullSubspace()
    {
        List<int> allPossibleValues = new List<int>();
        for (int i = 1; i <= 9; i++)
        {
            allPossibleValues.Add(i);
        }
        return allPossibleValues;
    }
}
