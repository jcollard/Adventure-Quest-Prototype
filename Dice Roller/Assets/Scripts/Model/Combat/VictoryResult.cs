using System.Collections.Generic;
using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class VictoryResult : CombatResult
    {
        public VictoryResult(int gold) : this(gold, null) {}
        public VictoryResult(int gold, IEnumerable<IItem> loot) : base("Victory!")
        {
            Gold = gold;
            Loot = loot != null ? new(loot) : new();
        }

        public int Gold { get; }
        public List<IItem> Loot { get; }
    }
}