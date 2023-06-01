using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.AssignAndEnroll;

public class StudentEnrollment
{
    private YeshivaContext db;
    private NumberChooser number = new NumberChooser();
    private ListAndPickTypes ListAndPick;

    public StudentEnrollment(YeshivaContext database)
    {
        db = database;
        ListAndPick = new ListAndPickTypes(db);
    }
    public void run()
    {
        Console.WriteLine("1. Enroll student in shiur\n" +
                          "2. Un-enroll student in shiur\n");
                
        int choice = number.ChooseNumber(2);
        
        
        switch (choice)
        {
            case -1:
                break;
            case 1:
                enrollStudent();
                break;
            case 2:
                unenrollStudent();
                break;
        }
    }

    private void enrollStudent()
    {
        Student student = ListAndPick.AStudent("enroll");
        Shiur shiur = ListAndPick.AShiur($"place {student.Name} in");
        try
        {
            student.Shiur = shiur;
            db.SaveChanges();
            Console.WriteLine($"{student.Name} enrolled in {shiur.Name} successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was a problem enrolling {student.Name} in {shiur.Name}");
        }   
    }

    private void unenrollStudent()
    {
        Student student = ListAndPick.AStudent("unenroll");
        try
        {
            student.Shiur = null;
            db.SaveChanges();
            Console.WriteLine($"{student.Name} unenrolled successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was a problem unenrolling {student.Name}");
        }      
    }
}