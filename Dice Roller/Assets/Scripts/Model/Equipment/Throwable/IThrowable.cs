using AdventureQuest.Combat;

namespace AdventureQuest.Equipment
{
    public interface IThrowable : IUseable
    {
        public string Throw(ICombatant user, ICombatant target);
    }
}