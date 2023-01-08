using System.Collections.Generic;
using System.Linq;

namespace AdventureQuest.Utils
{
    public static class DictionaryExtensions
    {
        public static bool DeepCompare<K,V>(this Dictionary<K, V> dict0, Dictionary<K, V> dict1)
        {
            return dict0.Count == dict1.Count && 
                   dict0.All(pair => dict1.ContainsKey(pair.Key) && dict1[pair.Key].Equals(pair.Value));
        }
    }
}