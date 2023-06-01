using MCON368CourseProject.Tasks.DisplayDetails;
using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class SearchMenu : Menu
{
    private string searchType;
    private NumberChooser number = new NumberChooser();
    private StringChooser letter = new StringChooser();
    private Menu prevMenu;
    public YeshivaContext db;
    private StudentDetailsDisplayer display;

    public SearchMenu(string type, Menu menu, YeshivaContext database)
    {
        searchType = type;
        prevMenu = menu;
        db = database;
        display = new StudentDetailsDisplayer(db);
    }
    
    public override void run()
    {
        Console.WriteLine($"SEARCH {searchType.ToUpper()} RECORDS - PRESS Q TO RETURN TO PREVIOUS MENU\n" +
                          $"1. Search by name\n" +
                          $"2. Search by ID");
        
        int choice = number.ChooseNumber(2);
        
        switch (choice)
        {
            case -1:
                break;
            case 1:
                searchByName();
                break;
            case 2:
                searchByID();
                break;
        }
        
        prevMenu.run();
    }

    private void searchByName()
    {
        var name = letter.ChooseString("Search student by name: ");
        var results = db.Student
            .Where(y => y.Name.ToUpper().Contains($"{name.ToUpper()}"));
        
        if (!results.Any())
        {
            Console.WriteLine("No student names matched your search. Returning to search menu.");
            this.run();
            return;
        }
        
        findAndDisplayChosenStudent(results);
    }
    private void searchByID()
    {
        Console.WriteLine("Search student by id: ");
        var id = number.ChooseNumber(db.Student.Max(x => x.StudentID));
        var results = db.Student
            .Where(y => y.StudentID.ToString().Contains($"{id.ToString()}"));

        if (!results.Any())
        {
            Console.WriteLine("No student ids matched your search. Returning to search menu.");
            this.run();
            return;
        }
        
        findAndDisplayChosenStudent(results);
    }

    private void findAndDisplayChosenStudent(IQueryable<Student> results)
    {
        Student chosen;
        if (results.Count() > 1)
        {
            var count = 1;
            foreach (var s in results)
            {
                Console.WriteLine($"{count}. ID: {s.StudentID} Name: {s.Name}");
                count++;
            }

            Console.WriteLine($"Which Student would you like to search?");
            var studentCount = results.Count();
            var student = number.ChooseNumberOnly(studentCount);
            chosen = results.ToList()[student-1];
        }
        else
        {
            chosen = results.ToList()[0];
        }
        
        Console.WriteLine($"Searching student: {chosen.StudentID} {chosen.Name}");
        display.RunSingle(chosen);    
    }

}