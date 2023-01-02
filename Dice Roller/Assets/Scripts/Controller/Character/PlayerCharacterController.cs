using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Character
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private PlayerCharacter _playerCharacter;
        [field: SerializeField]
        public UnityEvent<PlayerCharacter> OnChange { get; private set; }
        public PlayerCharacter PlayerCharacter 
        { 
            get => _playerCharacter; 
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("Cannot set player to null.");
                }
                _playerCharacter = value;
                OnChange.Invoke(_playerCharacter);
            }
        }

        protected void Start()
        {
            PlayerCharacter = new PlayerCharacter("Bob", Abilities.Roll());
            
        }

    }
}