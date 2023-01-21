using System.Collections.Generic;
using System.Diagnostics;

namespace AdventureQuest.Equipment
{
    public class Loot
    {
        public static readonly Loot NoLoot = new(0);
        public Loot(int gold) : this(gold, new ()) { }
        public Loot(int gold, List<IItem> items)
        {
            UnityEngine.Debug.Assert(gold >= 0, "Loot may not have a negative gold amount.");
            Gold = gold;
            Items = new (items);
        }
        public int Gold { get; }
        public List<IItem> Items { get; }
    }
}