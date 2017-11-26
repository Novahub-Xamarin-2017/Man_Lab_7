using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Program
    {
        private static IEnumerable<string> GetAllFiles(string folder, Predicate<string> filter)
        {
            foreach (var file in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
            {
                if (filter(file))
                {
                    yield return file;
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (var file in GetAllFiles(@"D:\Tumblers", x => x.EndsWith(".apk")))
            {
                Console.WriteLine(file);
            }
            Console.ReadKey();
        }
    }
}
