using System;

public class SudokuGrid
{
    public int[] inputArray = new int[81];

    public SudokuGrid()
    {
        inputArray = GetInputs();
    }

    public int UnknownSquares
    {
        get
        {
            return GetUnknownSquares();
        }
    }

    private int[] GetInputs()
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
                inputArray[i] = int.Parse(inputString[i].ToString());
            }
            else
            {
                inputArray[i] = 0;
            }
        }

        return inputArray;
    }
    private int GetUnknownSquares()
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
