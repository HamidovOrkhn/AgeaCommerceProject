using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Extensions
{
    public static class ListExtension
    {
        public static List<T> TakeLastSafe<T>(this List<T> lst, int count)
        {
            if (lst.Count < count)
            {
                return lst;
            }
            else
            {
                return lst.TakeLast(count).ToList();
            }
        }
        public static List<T> TakeSafe<T>(this List<T> lst, int count)
        {
            if (lst.Count < count)
            {
                return lst;
            }
            else
            {
                return lst.Take(count).ToList();
            }
        }
    }
}
