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
        
        public ICombatant Enemy { get; set; }

        public void PlayerAttack()
        {
            AttackResult result = _player.PlayerCharacter.Attack(Enemy);
            Debug.Log(result.Description);
        }
        
    }
}
