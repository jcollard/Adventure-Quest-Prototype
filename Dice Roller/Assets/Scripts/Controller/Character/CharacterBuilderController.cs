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
        private string _portraitSpriteKey = string.Empty;

        [field: SerializeField]
        public UnityEvent<Abilities> OnChange { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnError { get; private set; }
        
        public string Name { 
            get => _name; 
            set
            {
                if (!IsValidName(value))
                {
                    OnError.Invoke("Character name must be at least 3 characters.");
                    return;
                }
                _name = value;
            }   
        }

        public string PortraitSpriteKey
        {
            get => _portraitSpriteKey;
            set
            {
                if (value == null) { throw new System.ArgumentException("Cannot set portrait to null."); }
                _portraitSpriteKey = value;                
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
        
        public void ReRollAbilities()
        {
            Abilities = Abilities.Roll();
        }

        public void CreateCharacter()
        {
            if (!IsValidName(Name))
            {
                OnError.Invoke("You must name your character.");
                return;
            }
            PlayerCharacter character = new (Name, Abilities, PortraitSpriteKey);
            string asJson = JsonUtility.ToJson(character);
            Debug.Log(asJson);
        }

        protected void Start()
        {
            Abilities = Abilities.Roll();
        }

        private static bool IsValidName(string name)
        {
            return name != null && name.Length >= 3;
        }        

    }
}