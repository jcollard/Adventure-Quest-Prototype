using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Character;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class CombatController : MonoBehaviour
    {
        [SerializeField]
        private Character.CharacterController _player;
        [SerializeField]
        private Character.CharacterController _enemy;

        public void PlayerAttack()
        {
            AttackResult result = _player.PlayerCharacter.Attack(_enemy.PlayerCharacter);
            Debug.Log(result.Description);
        }
        
    }
}
