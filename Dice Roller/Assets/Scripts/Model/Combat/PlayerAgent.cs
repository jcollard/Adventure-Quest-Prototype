
using System.Threading.Tasks;

namespace AdventureQuest.Combat
{
    public class PlayerAgent : ICombatAgent
    {
        public ICombatAction SelectAction(CombatManager manager)
        {
            return new AttackAction(manager.Player, manager.Enemy);
        }
    }
}