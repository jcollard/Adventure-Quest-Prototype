using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Shop.UI
{
    [RequireComponent(typeof(ConfirmCancelDialog))]
    public class SellDialog : MonoBehaviour
    {
        private SaleProposalRenderer _renderer;

        public SaleProposal SaleProposal 
        { 
            set 
            {
                gameObject.SetActive(true);
                _renderer.Render(value);                 
            }
        }

        protected void Awake()
        {
            _renderer = transform.GetComponentInChildren<SaleProposalRenderer>(true);
            if (_renderer == null)
            {
                throw new System.InvalidOperationException($"Unable to create Sell Dialog. Could not find SaleProposalRenderer");
            }
        }
        
        
    }
}
