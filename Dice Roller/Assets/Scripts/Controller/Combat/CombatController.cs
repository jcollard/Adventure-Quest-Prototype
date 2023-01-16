using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Character;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class CombatController : MonoBehaviour
    {
        [SerializeField]
        private Character.CharacterController _player;

        public ICombatant Enemy { get; set; }

        [field: SerializeField]
        public UnityEvent<AttackResult> OnCombatEvent { get; private set; } = new();

        public void PlayerAttack()
        {
            AttackResult result = _player.PlayerCharacter.Attack(Enemy);
            OnCombatEvent.Invoke(result);
            Debug.Log(result.Description);
        }
    }
}
