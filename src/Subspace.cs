using System.Collections.Generic;

public class Subspace
{
    public Subspace()
    {

    }

    public static List<int> AllPossibleValues()
    {
                    List<int> allPossibleValues = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                allPossibleValues.Add(i);
            }
            return allPossibleValues;
    }
}
