using UnityEngine;
using UnityEngine.Events;
using TMPro;

using AdventureQuest.Character.Dice;
using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{

    public class InventoryRenderer : MonoBehaviour
    {
        [SerializeField]
        private InventoryObservable _defaultController;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private InventoryItemRenderer _itemTemplate;
        [SerializeField]
        private Transform _itemList;

        [field: SerializeField]
        public UnityEvent<IItem> OnSelectItem { get; private set; }

        

        // Start is called before the first frame update
        void Awake()
        {
            if (_defaultController != null)
            {
                _defaultController.OnChange.AddListener(Render);
            }
        }
        public void Render(IHasInventory hasInventory) => Render(hasInventory.Inventory);

        public void Render(IInventory inventory)
        {
            foreach (Transform child in _itemList)
            {
                Destroy(child.gameObject);
            }
            _name.text = inventory.Name;
            foreach (IItem item in inventory.Items)
            {
                InventoryItemRenderer entry = Instantiate(_itemTemplate, _itemList);
                entry.Render(item);
                entry.OnSelected.AddListener(() => OnSelectItem.Invoke(item));
            }
        }

    }

}