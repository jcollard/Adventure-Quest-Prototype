using AdventureQuest.Character;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Combat
{
    public class FleeAction : ICombatAction
    {
        private static readonly AbilityRoll _escapeRoll = AbilityRoll.Parse($"1d20 + {Ability.Agility}");
        private static readonly AbilityRoll _catchRoll = AbilityRoll.Parse($"1d20 + {Ability.Agility}");
        public FleeAction(ICombatant fleeing, ICombatant enemy)
        {
            Fleeing = fleeing;
            Enemy = enemy;
        }

        public ICombatant Fleeing { get; private set; }
        public ICombatant Enemy { get; private set; }

        public CombatResult PerformAction()
        {
            CombatResult result = new("Fleeing");
            result.Add($"{Fleeing.Name} looks afraid and attempts to flee from {Enemy.Name}.");
            int fleeRoll = _escapeRoll.Roll(Fleeing);
            int catchRoll = _catchRoll.Roll(Enemy);
            if (catchRoll > fleeRoll)
            {
                result.Add($"{Enemy.Name} catches {Fleeing.Name}. There is no escape.");
            }
            else
            {
                result.Title = "You Escaped!";
                result.Add($"{Fleeing.Name} escapes.");
                result.IsCombatOver = true;
            }
            return result;
        }
    }
}