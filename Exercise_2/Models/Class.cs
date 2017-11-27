using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2.Models
{
    class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Class(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
