using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class SearchMenu : Menu
{
    private string searchType;
    private NumberChooser choose = new NumberChooser();
    private Menu prevMenu;
    public YeshivaContext db;

    public SearchMenu(string type, Menu menu, YeshivaContext database)
    {
        searchType = type;
        prevMenu = menu;
        db = database;
    }
    
    public override void run()
    {
        Console.WriteLine($"SEARCH {searchType.ToUpper()} RECORDS - PRESS Q TO RETURN TO PREVIOUS MENU\n" +
                          $"1. Search by name\n" +
                          $"2. Search by ID");
        
        int choice = choose.ChooseNumber(2);
        
        switch (choice)
        {
            case -1:
                break;
            case 1: // TODO
                break;
            case 2: // TODO
                break;
        }
        
        prevMenu.run();
    }
}