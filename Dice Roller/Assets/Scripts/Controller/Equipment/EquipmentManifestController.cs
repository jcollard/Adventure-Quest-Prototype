using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{
    public class EquipmentManifestController : MonoBehaviour
    {
        public IHasEquipment HasEquipment { get; set; }
        public ICharacter Character { get; set; }
        [field: SerializeField]
        public EquipmentSlot? SelectedSlot { get; private set; }

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
                        
            Debug.Log($"Equipping {toEquip.Name} to {SelectedSlot} was {success}");
        }

    }
}