using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class AttackAction : ICombatAction
    {
        public AttackAction(ICombatant attacker, ICombatant target)
        {
            Attacker = attacker;
            Target = target;
        }

        public ICombatant Attacker { get; private set; }
        public ICombatant Target { get; private set; }

        public CombatResult PerformAction() => Attacker.Attack(Target);
    }
}