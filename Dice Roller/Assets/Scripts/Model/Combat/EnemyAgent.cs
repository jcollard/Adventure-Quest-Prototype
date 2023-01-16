
using System.Threading.Tasks;

namespace AdventureQuest.Combat
{
    public class EnemyAgent : ICombatAgent
    {
        public ICombatAction SelectAction(CombatManager manager)
        {
            return new AttackAction(manager.Enemy, manager.Player);
        }
    }
}