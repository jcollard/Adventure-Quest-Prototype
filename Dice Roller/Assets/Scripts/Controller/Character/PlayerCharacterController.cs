using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Character
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [field: SerializeField]
        private PlayerCharacter _playerCharacter;
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

        [field: SerializeField]
        public bool LoadFromStorageOnLoad { get; private set; }
        [field: SerializeField]
        public UnityEvent<PlayerCharacter> OnChange { get; private set; }

        protected void Start()
        {
            if (LoadFromStorageOnLoad)
            {
                PlayerCharacter = PlayerCharacter.Restore();
                return;
            }
        }

    }
}