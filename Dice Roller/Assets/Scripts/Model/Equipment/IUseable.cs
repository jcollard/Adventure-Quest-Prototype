using AdventureQuest.Combat;

namespace AdventureQuest.Equipment
{
    public interface IUseable : IItem
    {
        public string Use(ICombatant user);
    }
}