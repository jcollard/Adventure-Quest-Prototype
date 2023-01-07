using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Shop.UI
{
    public class ConfirmCancelDialog : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent OnConfirm { get; private set; }
        [field: SerializeField]
        public UnityEvent OnCancel { get; private set; }

        public void Confirm() => OnConfirm.Invoke();
        public void CancelDialog() => OnCancel.Invoke();       
        
    }
}
