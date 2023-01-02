using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Character
{
    public class CharacterBuilderController : MonoBehaviour
    {

        private Abilities _abilities;
        private string _name = string.Empty;

        [field: SerializeField]
        public UnityEvent<Abilities> OnChange { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnError { get; private set; }
        
        public string Name { 
            get => _name; 
            set
            {
                if (value == null || value.Length < 3)
                {
                    OnError.Invoke("Character name must be at least 3 characters.");
                    return;
                }
                _name = value;
            }
            
        }

        public Abilities Abilities
        {
            get => _abilities;
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("Cannot set player to null.");
                }
                _abilities = value;
                OnChange.Invoke(_abilities);
            }
        }

        protected void Start()
        {
            Abilities = Abilities.Roll();
        }
        
        public void ReRollAbilities()
        {
            Abilities = Abilities.Roll();
        }

    }
}