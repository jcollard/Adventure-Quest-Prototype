using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;
using AdventureQuest.Character;

namespace AdventureQuest.Shop
{

    public class ShopInventoryController : MonoBehaviour
    {

        [SerializeField]
        private ShopItemEntryController _itemTemplate;
        [SerializeField]
        private Transform _itemList;

        [field: SerializeField]
        public UnityEvent<IItem> OnSelectItem { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            List<IItem> inventory = new()
            {
                new Weapon("Dagger", 3, AbilityRoll.Parse($"1d4 + {Ability.Dexterity}")),
                new Weapon("Sword", 6, AbilityRoll.Parse($"1d6 + {Ability.Strength}")),
            };

            Shop testShop = new(inventory);
            Render(testShop);
        }

        public void Render(IShop shop)
        {
            foreach (Transform child in _itemList)
            {
                Destroy(child.gameObject);
            }
            foreach (IItem item in shop.Items)
            {
                ShopItemEntryController entry = Instantiate(_itemTemplate, _itemList);
                entry.Render(item);
                entry.OnSelected.AddListener(() => OnSelectItem.Invoke(item));
            }
        }
    }

}