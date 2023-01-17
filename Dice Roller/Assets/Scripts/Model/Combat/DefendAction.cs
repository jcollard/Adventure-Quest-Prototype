using AdventureQuest.Entity;

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
            CombatResult result = new ();
            result.Add($"{Defender.Name} defends themselves.");
            // TODO: Implement details of Defending.
            return result;
        }
    }
}