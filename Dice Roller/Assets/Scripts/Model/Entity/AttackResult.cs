namespace AdventureQuest.Entity
{

    public class AttackResult 
    {

        public AttackResult(ICombatant attacker, ICombatant defender, string description)
        {
            Attacker = attacker;
            Defender = defender;
            Description = description;
        }

        public ICombatant Attacker { get; }
        public ICombatant Defender { get; }
        public string Description { get; }
    }

}