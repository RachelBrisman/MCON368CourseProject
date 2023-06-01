namespace MCON368CourseProject.Utils;

public class TypesToString
{
    public YeshivaContext db;
    public TypesToString(YeshivaContext database)
    {
        db = database;
    }
    public string StudentToString(Student s)
    {
        var studentsShiur = db.Shiur.First(x => x.ShiurID == s.ShiurID);
        var studentsRebbi = db.Rebbi.First(x => studentsShiur.RebbiId == x.RebbiID);
        return $"Name: {s.Name}. Address: {s.Address}. " +
               $"Shiur: {studentsShiur.Name}. Rebbi: {studentsRebbi.Name}";
    }

    public string ShiurToString(Shiur s)
    {
        var shiursRebbi = db.Rebbi.First(x => x.RebbiID == s.RebbiId);
        var shiursStudents = db.Student.Where(x => x.ShiurID == s.ShiurID);
        string students ="";
        foreach (var student in shiursStudents)
        {
            students += student.Name + " ";
        }
        
        return $"Name: {s.Name}. Subject: {s.Subject}. Start Date: {s.StartDate}. " +
               $"Rebbi: {shiursRebbi.Name}. Students: {students}";
    }

    public string RebbiToString(Rebbi r)
    {
        var rebbisShiurs = db.Shiur.Where(x => x.RebbiId == r.RebbiID);
        string shiurs ="";
        foreach (var shiur in rebbisShiurs)
        {
            shiurs += shiur.Name + " ";
        }
        return $"Name: {r.Name}. Address: {r.Address}. Shiurs: {shiurs}";
    }
}