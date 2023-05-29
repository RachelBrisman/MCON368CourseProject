using MCON368CourseProject.ManageRecords;
using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class RecordMenu : Menu
{
    private string recordType;
    private NumberChooser choose = new NumberChooser();
    private Menu prevMenu;
    private RecordManager manager;
    public YeshivaContext db;

    public RecordMenu(string type, Menu menu, YeshivaContext database)
    {
        recordType = type;
        prevMenu = menu;
        db = database;
        switch (type)
        {
            case "Student":
                manager = new StudentRecordManager(db);
                break;
            case "Rebbi":
                manager = new RebbiRecordManager(db);
                break;
            case "Shiur":
                manager = new ShiurRecordManager(db);
                break;
        }
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
                break;
            case 1:
                manager.add();
                break;
            case 2:
                manager.update();
                break;
            case 3:
                manager.delete();
                break;
        }
        prevMenu.run();
    }
}