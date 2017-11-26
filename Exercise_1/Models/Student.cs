using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Score { get; set; }

        public Student(int id, string name, DateTime birthday, double score)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Score = score;
        }

        public override string ToString() => $"\nId: {Id}" +
                                             $"\nName: {Name}" +
                                             $"\nBirthday: {Birthday.ToString("MM/dd/yyyy")}" +
                                             $"\nScore: {Score}";

    }
}
