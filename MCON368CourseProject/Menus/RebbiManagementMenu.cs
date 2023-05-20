using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class RebbiManagementMenu
{
    public void run()
    {
        Console.WriteLine("REBBI MANAGEMENT - PRESS Q TO RETURN TO PREVIOUS MENU");
        Console.WriteLine("Enter the number of the command you would like to use.");
        Console.WriteLine("1. Manage Rebbi records\n" +
                          "2. Assign Shiur to Rebbi\n" +
                          "3. Display Rebbi details");
        
        NumberChooser choose = new NumberChooser();
        int chosen = choose.ChooseNumber(3);

        switch (chosen)
        {
            case -1:
                MainMenu main = new MainMenu();
                main.run();
                break;
            case 1: // TODO
                Console.WriteLine("1. Add Rebbi record\n" +
                                  "2. Update Rebbi record\n" +
                                  "3. Delete Rebbi record\n");

                int choice = choose.ChooseNumber(3);
                break;
            case 2: // TODO
                break;
            case 3: // TODO
                break;
        }
    }
}