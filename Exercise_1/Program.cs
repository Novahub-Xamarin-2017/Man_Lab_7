using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_1.Models;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student(1, "Student 1", new DateTime(1993, 7, 21), 8.5),
                new Student(2, "Student 2", new DateTime(1990, 2, 23), 9),
                new Student(3, "Student 3", new DateTime(1992, 3, 4), 8),
                new Student(4, "Student 4", new DateTime(1991, 12, 29), 8.5),
                new Student(5, "Student 5", new DateTime(1994, 5, 29), 7.5),
                new Student(6, "Student 6", new DateTime(1995, 2, 22), 6.0),
                new Student(7, "Student 7", new DateTime(1996, 10, 21), 7.0),
                new Student(5, "Student 5", new DateTime(1997, 2, 9), 4.5)
            };
            Console.Write("List of students have score >= 8: ");
            students.FindAll(x => x.Score >= 8).OrderBy(x => x.Birthday).ToList().ForEach(Console.WriteLine);

            Console.Write("List of students have score in (5.0 - 7.5): ");
            students.FindAll(x => x.Score >= 5.0 && x.Score <= 7.5).OrderBy(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.Write("List of students have score in (6.0 - 8.0) and birthday year in (1990 - 1992): ");
            students
                .FindAll(x => x.Score >= 6.0 && x.Score <= 8.0)
                .FindAll(x => x.Birthday.Year >= 1990 && x.Birthday.Year <= 1992)
                .ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
