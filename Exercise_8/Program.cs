using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new List<int> {1, 2, 3};
            var array2 = new List<int> {2, 3, 4};

            var commonNumbers = array1.Intersect(array2).ToList();
            commonNumbers.ForEach(Console.WriteLine);

            var numbersExistFromArray1ButArray2 = array1.Except(array2);
            numbersExistFromArray1ButArray2.ToList().ForEach(Console.WriteLine);

            var numbersExistFromOnlyOneArray = array1.Union(array2).Except(commonNumbers);
            numbersExistFromOnlyOneArray.ToList().ForEach(Console.WriteLine);

            var multiplication = array1.Aggregate((n1, n2) => n1 * n2);
            Console.WriteLine(multiplication);

            var multiOr = array1.Aggregate((n1, n2) => n1 | n2);
            Console.WriteLine(multiOr);

            var min = array1.Count > array2.Count ? array2.Count : array2.Count;
            var sum = array1.Sum() * array2.Sum() - Enumerable.Range(0, min).Sum(i => array1[i] * array2[i]);
            Console.WriteLine(sum);

            Console.ReadKey();

        }
    }
}
