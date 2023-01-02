using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Character
{
    public class CharacterBuilderController : MonoBehaviour
    {

        private Abilities _abilities;

        [field: SerializeField]
        public UnityEvent<Abilities> OnChange { get; private set; }

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