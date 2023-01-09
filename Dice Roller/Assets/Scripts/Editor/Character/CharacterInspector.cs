#if UNITY_EDITOR

using AdventureQuest.Character;
using UnityEngine;

namespace AdventureQuest.Editor.Character
{
    public class CharacterInspector : MonoBehaviour
    {

        [SerializeField]
        private ObservableCharacter _observableCharacter;

        protected void OnEnable()
        {
            if (_observableCharacter == null) { throw new System.InvalidOperationException("CharacterInspector must have ObservableCharacter."); }

            _observableCharacter.OnChange.AddListener(character => Character = character);
            
        }

        public ICharacter Character { get; private set; }
    }
}

#endif