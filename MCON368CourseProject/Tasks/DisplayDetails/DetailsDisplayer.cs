using MCON368CourseProject.Utils;

namespace MCON368CourseProject.DisplayDetails;

public abstract class DetailsDisplayer
{
    public TypesToString toString = new TypesToString();
    public abstract void run();
}