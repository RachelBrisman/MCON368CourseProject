using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.AssignAndEnroll;

public class AssignShiurToRebbi
{
    private YeshivaContext db;
    private ListAndPickTypes ListAndPick;

    public AssignShiurToRebbi(YeshivaContext database)
    {
        db = database;
        ListAndPick = new ListAndPickTypes(db);
    }
    
    public void run()
    {
        Rebbi rebbi = ListAndPick.ARebbi("assign a shiur to");
        Shiur shiur = ListAndPick.AShiur($"pick for this {rebbi.Name}");
        try
        {
            shiur.Rebbi = rebbi;
            db.SaveChanges();
            Console.WriteLine($"{shiur.Name} assigned to {rebbi.Name} assigned successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was a problem assigning {shiur.Name} to {rebbi.Name}");
        }
    }
}