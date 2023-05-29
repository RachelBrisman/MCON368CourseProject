using System.Runtime.CompilerServices;

namespace MCON368CourseProject.Utils;

public class NumberChooser
{
    public int ChooseNumber(int max)
    {
        Console.Write("Your choice: ");
        var result = Console.ReadLine();
        int final;
        while (isInvalidChoice(result, max, out final))
        {
            Console.Write("Choose a valid number: ");
            result = Console.ReadLine();
        }

        return final;
    }

    private bool isInvalidChoice(string result, int max, out int final)
    {
        if (isIntInRange(result, max, out final) || isExitCommand(result, out final))
        {
            return false;
        }

        final = -1;
        return true;
    }

    private bool isIntInRange(string result, int max, out int final)
    {
        if (int.TryParse(result, out var resultAsInt))
        {
            if (resultAsInt > 0 && resultAsInt <= max)
            {
                final = resultAsInt;
                return true;
            }
        }

        final = -2;
        return false;
    }

    private bool isExitCommand(string result, out int final)
    {
        if (result.ToLower().Trim().Equals("q"))
        {
            final = -1;
            return true;
        }

        final = -2;
        return false;
    }
}