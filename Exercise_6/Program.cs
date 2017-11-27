using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            var primeNumbersSmallerThanNumber = Enumerable.Range(2, number - 1).Where(x => x.IsPrime()).ToList();
            primeNumbersSmallerThanNumber.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
