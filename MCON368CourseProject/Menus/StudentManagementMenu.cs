using MCON368CourseProject.DisplayDetails;
using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class StudentManagementMenu : Menu
{        
    NumberChooser choose = new NumberChooser();
    public YeshivaContext db;

    public StudentManagementMenu(YeshivaContext database)
    {
        db = database;
    }
    
    public override void run()
    {
        Console.WriteLine("STUDENT MANAGEMENT - PRESS Q TO RETURN TO PREVIOUS MENU\n" +
                          "Enter the number of the command you would like to use.");
        Console.WriteLine("1. Manage student records\n" +
                          "2. Search for student\n" +
                          "3. Display student details");

        int chosen = choose.ChooseNumber(3);

        switch (chosen)
        {
            case -1:
                MainMenu main = new MainMenu(db);
                main.run();
                break;
            case 1: // TODO
                Menu records = new RecordMenu("Student", this, db);
                records.run();
                break;
            case 2: // TODO
                Menu searches = new SearchMenu("Student", this, db);
                searches.run();
                break;
            case 3: // TODO
                DetailsDisplayer details = new StudentDetailsDisplayer(db);
                details.run();
                this.run();
                break;
        }
    }
}