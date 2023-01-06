using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Equipment;
using TMPro;

namespace AdventureQuest.Shop
{

    public class ShopItemEntryController : MonoBehaviour
    {
        
        [field: SerializeField]
        public UnityEvent OnSelected { get; private set; }
        [field: SerializeField]
        public TextMeshProUGUI Name { get; private set; }
        [field: SerializeField]
        public TextMeshProUGUI Cost { get; private set; }
        
        public void Render(IItem item)
        {
            Name.text = item.Name;
            Cost.text = item.Cost.ToString();
        }

        public void Select() => OnSelected.Invoke();
    }

}