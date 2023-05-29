using MCON368CourseProject.DisplayDetails;
using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class RebbiManagementMenu : Menu
{
    NumberChooser choose = new NumberChooser();
    public YeshivaContext db;

    public RebbiManagementMenu(YeshivaContext database)
    {
        db = database;
    }

    public override void run()
    {
        Console.WriteLine("REBBI MANAGEMENT - PRESS Q TO RETURN TO PREVIOUS MENU");
        Console.WriteLine("Enter the number of the command you would like to use.");
        Console.WriteLine("1. Manage Rebbi records\n" +
                          "2. Assign Shiur to Rebbi\n" +
                          "3. Display Rebbi details");
        
        int chosen = choose.ChooseNumber(3);

        switch (chosen)
        {
            case -1:
                MainMenu main = new MainMenu(db);
                main.run();
                break;
            case 1:
                Menu records = new RecordMenu("Rebbi", this, db);
                records.run();
                break;
            case 2: // TODO
                break;
            case 3:
                DetailsDisplayer details = new RebbiDetailsDisplayer(db);
                details.run();
                this.run();
                break;
        }
    }
}