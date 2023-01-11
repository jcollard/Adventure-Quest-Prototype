using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.Equipment.UI
{

    [RequireComponent(typeof(EquipmentManifestController))]
    public class EquipmentManifestRenderer : MonoBehaviour
    {
        private Dictionary<EquipmentSlot, EquipmentSlotRenderer> _rendererLookup;

        protected void Awake()
        {
            EquipmentSlotRenderer[] slots = GetComponentsInChildren<EquipmentSlotRenderer>();
            _rendererLookup = new Dictionary<EquipmentSlot, EquipmentSlotRenderer>();
            foreach(EquipmentSlotRenderer slot in slots)
            {
                _rendererLookup[slot.Slot] = slot;
            }
            EquipmentManifestController controller = GetComponent<EquipmentManifestController>();
            controller.OnEquip.AddListener(Render);
        }

        public void Render(IItem item, EquipmentSlot slot) => _rendererLookup[slot].Render(item);

    }
}