namespace MCON368CourseProject;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class YeshivaContext : DbContext
{
    public DbSet<Shiur> Shiur { get; set; }
    public DbSet<Rebbi> Rebbi { get; set; }    
    public DbSet<Student> Student { get; set; }
    
    public string DbPath { get; }

    public YeshivaContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "yeshiva.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Shiur
{
    public int ShiurID { get; set; }
    public string Name { get; set; }
    public int RebbiId { get; set; }
    public string StartDate { get; set; }
    public string Subject { get; set; }
    
    public ICollection<Student> Students { get; set; }

    public Rebbi Rebbi { get; set; }
}

public class Rebbi
{
    public int RebbiID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<Shiur> Shiurs { get; set; }
}

public class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public int ShiurID { get; set; }
    public Shiur Shiur { get; set; }
}