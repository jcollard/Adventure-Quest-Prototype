using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using AdventureQuest.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AdventureQuest.Equipment.UI
{

    [RequireComponent(typeof(EquipmentManifestController))]
    public class EquipmentManifestRenderer : MonoBehaviour
    {
        private Transform _canvas;
        private Dictionary<EquipmentSlot, EquipmentSlotRenderer> _rendererLookup;

        protected void Awake()
        {
            _canvas = gameObject.GetComponentInParent<Canvas>().transform;            
            EquipmentSlotRenderer[] slots = GetComponentsInChildren<EquipmentSlotRenderer>();
            _rendererLookup = new Dictionary<EquipmentSlot, EquipmentSlotRenderer>();
            foreach(EquipmentSlotRenderer slotRenderer in slots)
            {
                _rendererLookup[slotRenderer.Slot] = slotRenderer;
                slotRenderer.Controller.OnDragBegin.AddListener(() => CreateDraggableItem(slotRenderer));
            }
            EquipmentManifestController controller = GetComponent<EquipmentManifestController>();
            controller.OnEquip.AddListener(Render);
        }

        public void Render(IItem item, EquipmentSlot slot) => _rendererLookup[slot].Render(item);

        private void CreateDraggableItem(EquipmentSlotRenderer slotRenderer)
        {
           Image img = slotRenderer.CloneImage(_canvas);
           DraggableController draggable = img.gameObject.AddComponent<DraggableController>();
        }
    }
}