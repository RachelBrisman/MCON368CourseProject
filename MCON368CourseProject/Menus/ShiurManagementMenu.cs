using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class ShiurManagementMenu : Menu
{
    NumberChooser choose = new NumberChooser();
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
                MainMenu main = new MainMenu();
                main.run();
                break;
            case 1: // TODO
                Menu records = new RecordMenu("shiur", this);
                records.run();
                break;
            case 2: // TODO
                break;
            case 3: // TODO
                Console.WriteLine("1. Enroll student in shiur\n" +
                                  "2. Un-enroll student in shiur\n");
                
                int choice = choose.ChooseNumber(3);
                break;
            case 4:
                break;
        }
    }
}