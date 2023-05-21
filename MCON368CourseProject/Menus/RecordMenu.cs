using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class RecordMenu : Menu
{
    private string recordType;
    private NumberChooser choose = new NumberChooser();
    private Menu prevMenu;

    public RecordMenu(string type, Menu menu)
    {
        recordType = type;
        prevMenu = menu;
    }
    
    public override void run()
    {
        Console.WriteLine($"MANAGE {recordType.ToUpper()} RECORDS - PRESS Q TO RETURN TO PREVIOUS MENU\n" +
                          $"1. Add {recordType} record\n" +
                          $"2. Update {recordType} record\n" +
                          $"3. Delete {recordType} record");
        
        int choice = choose.ChooseNumber(3);
        
        switch (choice)
        {
            case -1:
                prevMenu.run();
                break;
            case 1: // TODO
                break;
            case 2: // TODO
                break;
            case 3: // TODO
                break;
        }
    }
}