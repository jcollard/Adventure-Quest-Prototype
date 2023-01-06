using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Equipment;
using TMPro;

namespace AdventureQuest.Shop
{

    public class ItemEntryController : MonoBehaviour
    {
        [field: SerializeField]
        private TextMeshProUGUI _name;
        [field: SerializeField]
        private TextMeshProUGUI _cost;
        

        public UnityEvent OnSelected { get; private set; } = new UnityEvent();

        public virtual void Render(IItem item)
        {
            if (_name != null) { _name.text = item.Name; }
            if (_cost != null) { _cost.text = item.Cost.ToString(); }
        }

        public void Select() => OnSelected.Invoke();
    }

}