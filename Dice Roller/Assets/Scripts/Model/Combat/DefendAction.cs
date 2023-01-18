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
            CombatResult result = new ();
            result.Add($"{Defender.Name} defends themselves.");
            
            // TODO: This is pretty slow. We are looping through all effects twice O(N^2)
            // Consider using a HashSet<ICombatEffect> instead of a List
            foreach(ICombatEffect effect in Defender.Effects.Where(e => e is DefendBuff))
            {
                Defender.Effects.Remove(effect);
            }
            Defender.Effects.Add(new DefendBuff());

            return result;
        }
    }
}