using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class MainMenu
{
    public YeshivaContext db;

    public MainMenu(YeshivaContext database)
    {
        db = database;
    }
    public void run()
    {
        Console.WriteLine("Welcome to the Yeshiva Management System! Press Q to Exit.\n" +
                          "Enter the number of the program you would like to use.");
        Console.WriteLine("1. Student Management\n" +
                          "2. Shiur Management\n" +
                          "3. Rebbi Management\n" +
                          "4. Stats Module");
                  
        NumberChooser choose = new NumberChooser();
        int chosen = choose.ChooseNumber(4);
        
        switch (chosen)
        {
            case -1:
                Console.WriteLine("Thanks for using our System!");
                break;
            case 1:
                Menu studentPage = new StudentManagementMenu(db);
                studentPage.run();
                this.run();
                break;
            case 2:
                Menu shiurPage = new ShiurManagementMenu(db);
                shiurPage.run();
                this.run();
                break;
            case 3:
                Menu rebbiPage = new RebbiManagementMenu(db);
                rebbiPage.run();
                this.run();
                break;
            case 4:
                Menu stats = new StatsModuleMenu(db);
                stats.run();
                this.run();
                break;
        }
    }
}