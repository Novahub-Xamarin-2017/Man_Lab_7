using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach (var subListNumbers in numbers.SubList(3))
            {
                subListNumbers.ForEach(Console.Write);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
