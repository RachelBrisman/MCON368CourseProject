namespace MCON368CourseProject.Utils;

public class ListAndPickTypes
{
    private YeshivaContext db;
    private NumberChooser number = new NumberChooser();

    public ListAndPickTypes(YeshivaContext database)
    {
        db = database;
    }
    
    public Rebbi ARebbi(string action)
    {
        Console.WriteLine("Rebbis:");
        var count = 1;
        foreach (var r in db.Rebbi)
        {
            Console.WriteLine($"{count}. {r.Name}");
            count++;
        }

        Console.WriteLine($"Which Rebbi would you like to {action}?");
        var rebbiCount = db.Rebbi.Count();
        var rebbi = number.ChooseNumberOnly(rebbiCount);
        return db.Rebbi.ToList()[rebbi-1];
    }

    public Student AStudent(string action)
    {
        Console.WriteLine("Students:");
        var count = 1;
        foreach (var s in db.Student)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }

        Console.WriteLine($"Which Student would you like to {action}?");
        var studentCount = db.Student.Count();
        var student = number.ChooseNumberOnly(studentCount);
        return db.Student.ToList()[student-1];
    }

    public Shiur AShiur(string action)
    {
        Console.WriteLine("Shiurs:");
        var count = 1;
        foreach (var s in db.Shiur)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }

        Console.WriteLine($"Which Shiur would you like to {action}?");
        var shiurCount = db.Shiur.Count();
        var shiur = number.ChooseNumberOnly(shiurCount);
        return db.Shiur.ToList()[shiur-1];
    }
}