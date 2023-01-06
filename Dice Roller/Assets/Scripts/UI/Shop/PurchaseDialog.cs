using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Shop.UI
{
    public class PurchaseDialog : MonoBehaviour
    {
        private ItemInfoRenderer _renderer;

        [field: SerializeField]
        public UnityEvent OnConfirm { get; private set; }
        [field: SerializeField]
        public UnityEvent OnCancel { get; private set; }

        public IItem Item 
        { 
            set 
            {
                gameObject.SetActive(true);
                _renderer.RenderItemInfo(value);                 
            }
        }

        public void Confirm() => OnConfirm.Invoke();
        public void CancelDialog() => OnCancel.Invoke();

        protected void Awake()
        {
            _renderer = transform.GetComponentInChildren<ItemInfoRenderer>(true);
            if (_renderer == null)
            {
                throw new System.InvalidOperationException($"Unable to create Purchase Dialog. Could not find ItemInfoRenderer");
            }
        }
        
        
    }
}
