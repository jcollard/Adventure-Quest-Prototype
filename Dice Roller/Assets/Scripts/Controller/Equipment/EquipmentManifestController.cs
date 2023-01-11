using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using AdventureQuest.Character;
using AdventureQuest.UI;

namespace AdventureQuest.Equipment
{
    public class EquipmentManifestController : MonoBehaviour
    {
        [field: SerializeField]
        public bool CanDrop { get; set; }
        public IHasEquipment HasEquipment { get; set; }
        public ICharacter Character { get; set; }
        [field: SerializeField]
        public EquipmentSlot? SelectedSlot { get; private set; }
        [field: SerializeField]
        public UnityEvent<IItem, EquipmentSlot> OnEquip { get; private set; }
        [field: SerializeField]
        public UnityEvent<IItem, EquipmentSlot> OnUnequip { get; private set; }

        protected void Awake()
        {
            EquipmentSlotController[] slots = gameObject.GetComponentsInChildren<EquipmentSlotController>();
            foreach (EquipmentSlotController slot in slots)
            {
                slot.OnSelected.AddListener(() => SelectedSlot = slot.Slot);
                slot.OnDeselected.AddListener(() => SelectedSlot = null);
            }
        }

        public void Equip(IItem toEquip)
        {
            if (SelectedSlot == null) { return; }
            Debug.Assert(HasEquipment != null, "The EquipmentManifest was not loaded prior to equipping.");
            Debug.Assert(Character != null, "The Character was not loaded prior to equipping.");

            bool success = toEquip switch {
                IEquipable equipable => HasEquipment.Equipment.Equip(equipable, SelectedSlot.Value, Character),
                _ => false
            };

            if (success)
            {
                Character.Inventory.Remove(toEquip);
                OnEquip.Invoke(toEquip, SelectedSlot.Value);
            }
        }

        public void Unequip(EquipmentSlot slot)
        {
            if (!CanDrop) { return; }
            Debug.Assert(HasEquipment != null, "The EquipmentManifest was not loaded prior to unequipping.");
            Debug.Assert(Character != null, "The Character was not loaded prior to unequipping.");

            if(HasEquipment.Equipment.Equipped.TryGetValue(slot, out IEquipable toRemove))
            {
                if(HasEquipment.Equipment.Unequip(slot))
                {
                    //TODO: This should probably be part of Unequip
                    Character.Inventory.Add(toRemove);
                    OnUnequip.Invoke(toRemove, slot);
                }
            }
        }
    }
}