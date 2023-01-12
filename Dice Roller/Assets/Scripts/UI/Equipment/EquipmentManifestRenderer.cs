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
        private EquipmentManifestController _controller;
        private Dictionary<EquipmentSlot, EquipmentSlotRenderer> _rendererLookup;

        private Dictionary<EquipmentSlot, EquipmentSlotRenderer> RenderLookup
        {
            get 
            {
                if (_rendererLookup == null)
                {
                    EquipmentSlotRenderer[] slots = GetComponentsInChildren<EquipmentSlotRenderer>();
                     _rendererLookup = new Dictionary<EquipmentSlot, EquipmentSlotRenderer>();
                    foreach(EquipmentSlotRenderer slotRenderer in slots)
                    {
                        _rendererLookup[slotRenderer.Slot] = slotRenderer;
                        slotRenderer.Controller.OnDragBegin.AddListener(() => CreateDraggableItem(slotRenderer));
                    }
                }
                return _rendererLookup;
            }
        }

        protected void Awake()
        {
            _canvas = gameObject.GetComponentInParent<Canvas>().transform;
            // TODO: Initialize _renderLookup;    
            _controller = GetComponent<EquipmentManifestController>();
            _controller.OnEquip.AddListener(Render);
            _controller.OnUnequip.AddListener(ClearRender);
        }

        public void Render(IHasEquipment hasEquipment) => Render(hasEquipment.Equipment);
        public void Render(IEquipmentManifest equipment)
        {
            foreach (KeyValuePair<EquipmentSlot, IEquipable> equipped in equipment.Equipped)
            {
                Render(equipped.Value, equipped.Key);
            }
        }

        public void Render(IItem item, EquipmentSlot slot) => RenderLookup[slot].Render(item);
        public void ClearRender(IItem item, EquipmentSlot slot) => RenderLookup[slot].ClearRender();

        private void CreateDraggableItem(EquipmentSlotRenderer slotRenderer)
        {
           Image img = slotRenderer.CloneImage(_canvas);
           img.raycastTarget = false;
           DraggableController draggable = img.gameObject.AddComponent<DraggableController>();
           draggable.OnRelease.AddListener(() => _controller.Unequip(slotRenderer.Slot));
        }
    }
}