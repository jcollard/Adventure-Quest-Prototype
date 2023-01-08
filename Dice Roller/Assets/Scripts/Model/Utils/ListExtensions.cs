using System.Collections.Generic;
using System.Linq;

namespace AdventureQuest.Utils
{
    public static class ListExtensions
    {
        public static bool DeepCompare<T>(this List<T> list0, List<T> list1)
        {
            return list0.Count == list1.Count && 
                   list0.SequenceEqual(list1);
        }
    }
}