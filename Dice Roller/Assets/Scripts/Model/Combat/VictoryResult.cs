using System.Collections.Generic;
using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class VictoryResult : CombatResult
    {
        public VictoryResult(Loot loot) : base("Victory!")
        {
            Loot = loot;
        }

        public Loot Loot { get; }
    }
}