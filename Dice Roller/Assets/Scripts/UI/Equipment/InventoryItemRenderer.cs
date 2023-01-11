using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

namespace AdventureQuest.Equipment
{

    public class InventoryItemRenderer : MonoBehaviour
    {
        [field: SerializeField]
        private TextMeshProUGUI _name;
        [field: SerializeField]
        private TextMeshProUGUI _cost; 
        [field: SerializeField]
        private Image _highlighter;

        public UnityEvent OnSelected { get; private set; } = new UnityEvent();
        public UnityEvent OnDrag { get; private set; } = new UnityEvent();

        public virtual void Render(IItem item)
        {
            if (_name != null) { _name.text = item.Name; }
            if (_cost != null) { _cost.text = item.Cost.ToString(); }
        }

        public void Select() => OnSelected.Invoke();
        public void Drag() {
            OnDrag.Invoke();
        } 

        public void DisableRaycast()
        {
            _highlighter.raycastTarget = false;
            _highlighter.color = new Color(_highlighter.color.r, _highlighter.color.g, _highlighter.color.b, .2f);
        }
    }

}