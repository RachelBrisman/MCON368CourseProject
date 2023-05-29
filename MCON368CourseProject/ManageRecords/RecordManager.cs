using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public abstract class RecordManager
{
    private NumberChooser number = new NumberChooser();
    public abstract void add();
    public abstract void update();
    public abstract void delete();

    public int ChooseToUpdateOrKeep()
    {
        Console.WriteLine("1. Update\n2. Keep");
        var choice = number.ChooseNumber(2);
        return choice;
    }
}