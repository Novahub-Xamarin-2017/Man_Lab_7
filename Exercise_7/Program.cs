using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            var n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter m: ");
            var m = Convert.ToInt32(Console.ReadLine());

            var numbers = Enumerable.Range(1, m - 1).OrderBy(x => Guid.NewGuid()).Take(n).ToList();
            numbers.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
