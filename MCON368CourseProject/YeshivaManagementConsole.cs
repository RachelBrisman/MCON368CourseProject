using MCON368CourseProject;
using MCON368CourseProject.Menus;
using MCON368CourseProject.Utils;

using YeshivaContext db = new YeshivaContext();

MainMenu main = new MainMenu(db);
main.run();