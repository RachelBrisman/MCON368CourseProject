using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Menus;

public class StudentManagementMenu
{
    public void run()
    {
        Console.WriteLine("STUDENT MANAGEMENT - PRESS Q TO RETURN TO PREVIOUS MENU\n" +
                          "Enter the number of the command you would like to use.");
        Console.WriteLine("1. Manage student records\n" +
                          "2. Search for student\n" +
                          "3. Display student details");

        NumberChooser choose = new NumberChooser();
        int chosen = choose.ChooseNumber(3);

        switch (chosen)
        {
            case -1:
                MainMenu main = new MainMenu();
                main.run();
                break;
            case 1: // TODO
                Console.WriteLine("1. Add student record\n" +
                                  "2. Update student record\n" +
                                  "3. Delete Student record\n");

                int choice = choose.ChooseNumber(3);
                break;
            case 2: // TODO
                break;
            case 3: // TODO
                break;
        }
    }
}