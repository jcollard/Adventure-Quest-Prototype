
using UnityEngine;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;
using AdventureQuest.Character;
using UnityEngine.Events;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    [RequireComponent(typeof(ObservableShop), typeof(ObservableItem), typeof(ObservableCharacter))]
    public class ShopController : MonoBehaviour
    {

        private ObservableItem _selected;
        private ObservableShop _shop;
        private ObservableCharacter _character;

        [field: SerializeField]
        public UnityEvent<IItem> OnPurchase { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnFailure { get; private set; }

        private ObservableItem Selected 
        {
            get
            {
                if (_selected == null)
                {
                    _selected = GetComponent<ObservableItem>();
                }
                return _selected;
            }
        }

        private ObservableShop Shop 
        {
            get
            {
                if (_shop == null)
                {
                    _shop = GetComponent<ObservableShop>();
                }
                return _shop;
            }
        }

        private ObservableCharacter Character
        {
            get
            {
                if (_character == null)
                {
                    _character = GetComponent<ObservableCharacter>();
                }
                return _character;
            }
        }

        protected void Start()
        {
            
            IInventory shopInventory = new Inventory("Wilfred's Weapons");
            shopInventory.Add(new Weapon("Dagger", "A pointy dagger!", 3, AbilityRoll.Parse($"1d4 + {Ability.Dexterity}")));
            shopInventory.Add(new Weapon("Short Sword", "Light weight and sharp!", 6, AbilityRoll.Parse($"1d6 + {Ability.Strength}")));
            Shop shop = new Shop("Wilfred's Weapons", shopInventory);

            Shop.Observed = shop;
        }

        public void Purchase()
        {
            IResult result = Shop.Observed.Purchase(Selected.Observed, Character.Observed);
            if (result is Failure)
            {
                OnFailure.Invoke(result.Message);
            }
            else if (result is Success)
            {
                OnPurchase.Invoke(Selected.Observed);
            }
        }
    }    
}