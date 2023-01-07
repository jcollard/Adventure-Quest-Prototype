using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Shop.UI
{
    [RequireComponent(typeof(ConfirmCancelDialog))]
    public class PurchaseDialog : MonoBehaviour
    {
        private ItemInfoRenderer _renderer;
        public IItem Item 
        { 
            set 
            {
                gameObject.SetActive(true);
                _renderer.RenderItemInfo(value);                 
            }
        }

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
