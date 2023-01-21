using System.Collections.Generic;
using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class DefeatResult : CombatResult
    {
        public DefeatResult() : base("You Died!")
        {
            IsCombatOver = true;
        }
    }
}