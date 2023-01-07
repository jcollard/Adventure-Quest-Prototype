using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.UI.Character
{

    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterInventory : MonoBehaviour
    {

        private ICharacter _observing;

        void Awake()
        {
            ObservableCharacter character = GetComponent<ObservableCharacter>();
            InventoryRenderer renderer = GetComponentInChildren<InventoryRenderer>();
            character.OnChange.AddListener(ch => Observe(ch, renderer));            
        }

        void OnDestroy() {
            
        }

        private void Observe(ICharacter character, InventoryRenderer renderer)
        {
            if (_observing != null)
            {
                _observing.Inventory.OnChange -= renderer.Render;
            }
            renderer.Render(character);
            character.Inventory.OnChange += renderer.Render;
        }

        
    }

}