using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public double Score { get; set; }
        public int ClassId { get; set; }

        public Student(int id, string name, DateTime birthDay, double score, int classId)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
            Score = score;
            ClassId = classId;
        }
    }
}
