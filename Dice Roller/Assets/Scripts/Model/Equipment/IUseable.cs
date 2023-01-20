using AdventureQuest.Combat;

namespace AdventureQuest.Equipment
{
    public interface IUseable : IItem
    {
        public bool IsConsumedOnUse { get; }
        public string Use(ICombatant user);
    }
}