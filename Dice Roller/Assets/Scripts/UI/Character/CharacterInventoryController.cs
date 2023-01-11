using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.UI.Character
{

    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterInventoryController : MonoBehaviour
    {

        private ICharacter _observing;
        private System.Action<IInventory> _render;

        void Awake()
        {
            ObservableCharacter character = GetComponent<ObservableCharacter>();
            InventoryRenderer inventoryRenderer = GetComponentInChildren<InventoryRenderer>();
            CharacterRenderer characterRenderer = GetComponentInChildren<CharacterRenderer>();
            character.OnChange.AddListener(ch => Observe(ch, inventoryRenderer));
            character.OnChange.AddListener(characterRenderer.Render);
        }

        public void AddItem(IItem toAdd, EquipmentSlot _) => AddItem(toAdd);
        public void AddItem(IItem toAdd)
        {
            _observing.Inventory.Add(toAdd);
        }

        protected void OnDestroy() => ClearListener();

        private void Observe(ICharacter character, InventoryRenderer renderer)
        {
            ClearListener();
            _render = renderer.Render;
            _render.Invoke(character.Inventory);
            _observing = character;
            character.Inventory.OnChange += _render;
        }

        private void ClearListener()
        {
            if (_observing != null && _render != null)
            {
                _observing.Inventory.OnChange -= _render;
            }
        }


    }

}