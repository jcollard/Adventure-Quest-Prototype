using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class ThrowItemAction : ICombatAction
    {
        public ThrowItemAction(ICombatant user, ICombatant target, IThrowable item)
        {
            User = user;
            Target = target;
            Item = item;
        }

        public ICombatant User { get; private set; }
        public ICombatant Target { get; private set; }
        public IThrowable Item { get; private set; }

        public CombatResult PerformAction()
        {
            CombatResult result = new();
            result.Add(Item.Throw(User, Target));
            return result;
        }
    }
}