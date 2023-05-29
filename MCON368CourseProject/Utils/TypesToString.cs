namespace MCON368CourseProject.Utils;

public class TypesToString
{
    public string StudentToString(Student s)
    {
        return $"Name: {s.Name}. Address: {s.Address}. " +
               $"Shiur: {s.Shiur.Name}. Rebbi: {s.Shiur.Rebbi.Name}\n";
    }

    public string ShiurToString(Shiur s)
    {
        return $"Name: {s.Name}. Subject: {s.Subject}. Start Date: {s.StartDate}." +
               $"Rebbi: {s.Rebbi}. Students{s.Students}\n";
    }

    public string RebbiToString(Rebbi r)
    {
        return $"Name: {r.Name}. Address: {r.Address}. Shiurs: {r.Shiurs}\n";
    }
}