using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace AdventureQuest.Equipment
{
    public class EquipmentSlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [field: SerializeField]
        public EquipmentSlot Slot { get; private set; }

        [field: SerializeField]
        public UnityEvent OnSelected { get; private set; } = new ();
        [field: SerializeField]
        public UnityEvent OnDeselected { get; private set; } = new ();

        public void OnPointerEnter(PointerEventData eventData) => OnSelected.Invoke();
        public void OnPointerExit(PointerEventData eventData) => OnDeselected.Invoke();
    }
}