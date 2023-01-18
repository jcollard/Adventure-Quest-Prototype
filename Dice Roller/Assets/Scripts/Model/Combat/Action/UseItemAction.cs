using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class UseItemAction : ICombatAction
    {
        public UseItemAction(ICombatant user, ICombatant target, IUseable item)
        {
            User = user;
            Target = target;
            Item = item;
        }
        
        public ICombatant User { get; private set; }
        public ICombatant Target { get; private set; }
        public IUseable Item { get; private set; }

        public CombatResult PerformAction()
        {
            CombatResult result = new ();
            result.Add(Item.Use(Target));            
            return result;
        }
    }
}