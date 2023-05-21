using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class RebbiManagementMenu : Menu
{
    NumberChooser choose = new NumberChooser();

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
                MainMenu main = new MainMenu();
                main.run();
                break;
            case 1: // TODO
                Menu records = new RecordMenu("rebbi", this);
                records.run();
                break;
            case 2: // TODO
                break;
            case 3: // TODO
                break;
        }
    }
}