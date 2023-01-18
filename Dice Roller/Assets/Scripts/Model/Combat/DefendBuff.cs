using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class DefendBuff : ICombatEffect
    {
        private int _duration = 1;

        public DefendBuff()
        {

        }

        public string Name => "Defending";

        int ICombatEffect.Duration
        {
            get => _duration;
            set => _duration = value;
        }
        public int DefenseBonus => 5;

        public string EndMessage(ICombatant combatant) => $"{combatant.Name} stops defending.";
    }
}