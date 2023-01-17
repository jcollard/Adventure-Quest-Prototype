
using System;
using AdventureQuest.Character;

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

        public void Attack()
        {
            UnityEngine.Debug.Assert(IsReadyForAction, "The PlayerAgent is not ready to take an action.");
            if (_manager.NextToAct != _player) { return; }
            _onAction.Invoke(new AttackAction(_manager.Player, _manager.Enemy));
        }
    }
}