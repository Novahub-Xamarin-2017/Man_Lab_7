using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_6
{
    public static class IntegerExtension
    {
        public static bool IsPrime(this int number)
        {
            if (number < 2) return false;
            return Enumerable.Range(2, (int)Math.Sqrt(number) - 1).All(i => number % i != 0);
        }
    }
}
