using System.Text.RegularExpressions;

namespace MCON368CourseProject.Utils;

public class StringChooser
{
    public string ChooseString(string field)
    {
        Console.Write($"Name: ");
        var result = Console.ReadLine();
        while (!Regex.IsMatch(result, @"^[a-zA-Z\s]+$"))
        {
            Console.Write($"Choose a valid {field}: ");
            result = Console.ReadLine();
        }

        return result;
    }
}