using UnityEngine;
using UnityEngine.Events;
using TMPro;

using AdventureQuest.Character.Dice;
using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{

    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private ItemEntryController _itemTemplate;
        [SerializeField]
        private Transform _itemList;

        [field: SerializeField]
        public UnityEvent<IItem> OnSelectItem { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            // IInventory shopInventory = new Inventory
            IInventory shopInventory = new Inventory("Wilfred's Weapons");
            shopInventory.Add(new Weapon("Dagger", 3, AbilityRoll.Parse($"1d4 + {Ability.Dexterity}")));
            shopInventory.Add(new Weapon("Sword", 6, AbilityRoll.Parse($"1d6 + {Ability.Strength}")));

            // Shop testShop = new("Wilfred's Weapons", shopInventory);
            Render(shopInventory);
        }

        public void Render(IInventory inventory)
        {
            foreach (Transform child in _itemList)
            {
                Destroy(child.gameObject);
            }
            _name.text = inventory.Name;
            foreach (IItem item in inventory.Items)
            {
                ItemEntryController entry = Instantiate(_itemTemplate, _itemList);
                entry.Render(item);
                entry.OnSelected.AddListener(() => OnSelectItem.Invoke(item));
            }
        }
    }

}