
using System;

namespace AdventureQuest.Combat
{
    public class EnemyAgent : ICombatAgent
    {
        public void WaitForAction(CombatManager manager, Action<ICombatAction> onAction)
        {
            onAction.Invoke(new AttackAction(manager.Enemy, manager.Player));
        }
    }
}