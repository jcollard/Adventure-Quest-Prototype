
using System;
using System.Diagnostics;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Combat
{
    public class PlayerAgent : ICombatAgent
    {
        private CombatManager _manager;
        private Action<ICombatAction> _onAction;
        private ICharacter _player;
        public bool IsReadyForAction => _manager != null && _onAction != null;

        public PlayerAgent(ICharacter player)
        {
            _player = player;
        }

        public void WaitForAction(CombatManager manager, Action<ICombatAction> onAction)
        {
            _manager = manager;
            _onAction = onAction;
        }

        public void Attack() => SelectAction(new AttackAction(_manager.Player, _manager.Enemy));
        public void Flee() => SelectAction(new FleeAction(_manager.Player, _manager.Enemy));
        public void Defend() => SelectAction(new DefendAction(_manager.Player));

        public void UseItemFromInventory(IUseable useable)
        {
            Debug.Assert(_player.Inventory.Contains(useable), $"Player cannot use {useable.Name} because it is not in their inventory");
            UseItem(useable);
            if (useable.IsConsumedOnUse)
            {
                _player.Inventory.Remove(useable);
            }
        }

        public void ThrowItemFromInventory(IThrowable throwable, ICombatant target)
        {
            Debug.Assert(_player.Inventory.Contains(throwable), $"Player throw a {throwable.Name} because it is not in their inventory");
            // UseItem(throwable);
            SelectAction(new ThrowItemAction(_player, target, throwable));
            if (throwable.IsConsumedOnUse)
            {
                _player.Inventory.Remove(throwable);
            }
        }

        public void UseItem(IUseable usable) => SelectAction(new UseItemAction(_player, _player, usable));

        private void SelectAction(ICombatAction toPerform)
        {
            Debug.Assert(IsReadyForAction, "The PlayerAgent is not ready to take an action.");
            if (_manager.NextToAct != _player) { return; }
            _onAction.Invoke(toPerform);
        }
    }
}