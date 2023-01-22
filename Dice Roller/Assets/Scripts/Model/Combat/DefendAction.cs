using System.Linq;

namespace AdventureQuest.Combat
{
    public class DefendAction : ICombatAction
    {
        public DefendAction(ICombatant defender)
        {
            Defender = defender;
        }

        public ICombatant Defender { get; private set; }

        public CombatResult PerformAction()
        {
            CombatResult result = new ("Defend");
            result.Add($"{Defender.Name} defends themselves.");
            Defender.AddEffect(new DefendBuff());
            return result;
        }
    }
}