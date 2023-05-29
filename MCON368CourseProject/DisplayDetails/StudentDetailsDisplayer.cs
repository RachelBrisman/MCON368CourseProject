namespace MCON368CourseProject.DisplayDetails;

public class StudentDetailsDisplayer : DetailsDisplayer
{
    public YeshivaContext db;

    public StudentDetailsDisplayer(YeshivaContext database)
    {
        db = database;
    }

    public override void run()
    {
        // add rebbi
        foreach (var student in db.Student)
        {
            Console.WriteLine($"Name: {student.Name}. Address: {student.Address}. Shiur: {student.Shiur}.\n");
        }
    }
}