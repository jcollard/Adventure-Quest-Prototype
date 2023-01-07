using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.UI
{
    public class CharacterRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<string> OnChangeName { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnChangeGold { get; private set; }
        
        public void Render(ICharacter character)
        {
            OnChangeName.Invoke(character.Name);
            OnChangeGold.Invoke(character.Gold.ToString());
        }
    }
}