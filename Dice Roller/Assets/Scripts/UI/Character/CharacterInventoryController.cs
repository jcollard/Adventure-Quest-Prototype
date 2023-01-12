using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AdventureQuest.UI.Character
{

    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterInventoryController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {

        private ICharacter _observing;
        private System.Action<IInventory> _render;
        private InventoryRenderer _inventoryRenderer;

        void Awake()
        {
            ObservableCharacter character = GetComponent<ObservableCharacter>();
            _inventoryRenderer = GetComponentInChildren<InventoryRenderer>();
            CharacterRenderer characterRenderer = GetComponentInChildren<CharacterRenderer>();
            character.OnChange.AddListener(ch => Observe(ch, _inventoryRenderer));
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

        void IPointerMoveHandler.OnPointerMove(PointerEventData eventData) => _inventoryRenderer.OnPointerEnter();
        public void OnPointerEnter(PointerEventData eventData) => ((IPointerEnterHandler)_inventoryRenderer).OnPointerEnter(eventData);
        public void OnPointerExit(PointerEventData eventData) => ((IPointerExitHandler)_inventoryRenderer).OnPointerExit(eventData);
    }

}