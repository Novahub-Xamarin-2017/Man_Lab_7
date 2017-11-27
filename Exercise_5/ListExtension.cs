using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public static class ListExtension
    {
        public static IEnumerable<List<T>> SubList<T>(this IList<T> list, int max)
        {
            var subList = new List<T>();
            var count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                subList.Add(list[i]);
                count++;
                if (count == max || i == list.Count - 1)
                {
                    yield return subList;
                    subList = new List<T>();
                    count = 0;
                }
            }
        }
    }
}
