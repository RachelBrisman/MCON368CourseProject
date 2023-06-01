using MCON368CourseProject.Tasks.AssignAndEnroll;
using MCON368CourseProject.Tasks.DisplayDetails;
using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class ShiurManagementMenu : Menu
{
    private NumberChooser choose = new NumberChooser();
    public YeshivaContext db;

    public ShiurManagementMenu(YeshivaContext database)
    {
        db = database;
    }
    public override void run()
    {
        Console.WriteLine("SHIUR MANAGEMENT - PRESS Q TO RETURN TO PREVIOUS MENU");
        Console.WriteLine("Enter the number of the command you would like to use.");
        Console.WriteLine("1. Manage shiur records\n" +
                          "2. Assign Rebbi to shiur\n" +
                          "3. Manage shiur enrollment\n" +
                          "4. Display shiur details");
        
        int chosen = choose.ChooseNumber(4);

        switch (chosen)
        {
            case -1:
                MainMenu main = new MainMenu(db);
                main.run();
                return;
            case 1:
                Menu records = new RecordMenu("Shiur", this, db);
                records.run();
                break;
            case 2:
                AssignRebbiToShiur assign = new AssignRebbiToShiur(db);
                assign.run();
                break;
            case 3:
                StudentEnrollment enroller = new StudentEnrollment(db);
                enroller.run();
                break;
            case 4:
                ShiurDetailsDisplayer details = new ShiurDetailsDisplayer(db);
                details.run();
                break;
        }
        run();
    }
}