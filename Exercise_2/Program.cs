using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Exercise_2.Models;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student(1, "Student B", new DateTime(1997, 7, 21), 8, 1),
                new Student(2, "Student A", new DateTime(1997, 4, 1), 10, 1),
                new Student(3, "Student C", new DateTime(1996, 7, 1), 1, 1),
                new Student(4, "Student E", new DateTime(1995, 3, 5), 9, 1),
                new Student(5, "Student D", new DateTime(1997, 7, 2), 6, 1),
                new Student(6, "Student H", new DateTime(1997, 11, 21), 7, 2),
                new Student(7, "Student F", new DateTime(1984, 5, 12), 3, 2),
                new Student(8, "Student I", new DateTime(1997, 3, 2), 8, 2),
                new Student(9, "Student J", new DateTime(1997, 2, 3), 3.5, 2),
                new Student(10, "Student L", new DateTime(1997, 6, 21), 7.5, 2),
                new Student(11, "Student K", new DateTime(1997, 2, 14), 9.5, 2),
                new Student(12, "Student N", new DateTime(1997, 9, 6), 10, 3),
                new Student(13, "Student G", new DateTime(1997, 10, 21), 5, 3),
                new Student(14, "Student O", new DateTime(1997, 7, 8), 4, 3),
                new Student(15, "Student M", new DateTime(1997, 8, 9), 10, 3)
            };
            var classes = new List<Class>()
            {
                new Class(1, "Class 1"),
                new Class(2, "Class 2"),
                new Class(3, "Class 3")
            };

            ConsoleTable.From(students.OrderBy(x => x.ClassId).ThenBy(x => x.Name)).Write();

            var classesWithSudentCount = from c in classes
                                         join s in students
                                         on c.Id equals s.ClassId
                                         into selectedClasses
                                         select new
                                         {
                                             c.Id,
                                             c.Name,
                                             StudentCount = selectedClasses.Count()
                                         };
            ConsoleTable.From(classesWithSudentCount).Write();

            var classesWithStudentHighestScore = from c in classes
                                                 join s in students
                                                 on c.Id equals s.ClassId
                                                 into selectedClasses
                                                 select new
                                                 {
                                                     c.Id,
                                                     c.Name,
                                                     HighestScore = selectedClasses.Max(student => student.Score)
                                                 };
            ConsoleTable.From(classesWithStudentHighestScore).Write();

            var classesWithAverageScore = from c in classes
                                          join s in students
                                          on c.Id equals s.ClassId
                                          into selectedClasses
                                          select new
                                          {
                                              c.Id,
                                              c.Name,
                                              AverageScore = selectedClasses.Average(s => s.Score)
                                          };
            ConsoleTable.From(classesWithAverageScore).Write();

            var tenSudentsHaveHighestScore = (from s in students
                                              orderby s.Score descending
                                              select new
                                              {
                                                  s.Id,
                                                  s.Name,
                                                  s.Score,
                                                  s.BirthDay,
                                                  s.ClassId
                                              }).Take(10);
            ConsoleTable.From(tenSudentsHaveHighestScore).Write();

            var topThreeStudentsOfEachClass = (from c in classes
                                               select new
                                               {
                                                   c.Name,
                                                   Rank = (from s in students
                                                           orderby s.Score descending
                                                           join currentClass in classes
                                                           on s.ClassId equals currentClass.Id
                                                           where s.Score >= 8
                                                           where c.Id == currentClass.Id
                                                           select s).Take(3)
                                               });
            foreach (var item in topThreeStudentsOfEachClass)
            {
                Console.WriteLine(item.Name);
                ConsoleTable.From(item.Rank).Write();
            }

            var tenStudentsSelectedRandomly = students.OrderBy(x => Guid.NewGuid()).Take(10);
            ConsoleTable.From(tenStudentsSelectedRandomly).Write();

            Console.ReadKey();
        }
    }
}
