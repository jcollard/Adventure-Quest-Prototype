using System.Collections.Generic;
using System.Linq;

namespace AdventureQuest.Utils
{
    public static class EnumberableExtensions
    {
        public static Dictionary<T, int> SumHistogram<T>(this IEnumerable<Dictionary<T, int>> toSum)
        {
            Dictionary<T, int> modifiers = new();
            foreach (Dictionary<T, int> dict in toSum)
            {
                foreach (KeyValuePair<T, int> pairs in dict)
                {
                    if (modifiers.ContainsKey(pairs.Key))
                    {
                        modifiers[pairs.Key] = pairs.Value;
                    }
                    else
                    {
                        modifiers[pairs.Key] += pairs.Value;
                    }
                }
            }
            return modifiers;
        }
    }
}