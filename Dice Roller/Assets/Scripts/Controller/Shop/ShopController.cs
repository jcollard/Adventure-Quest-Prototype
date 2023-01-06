
using UnityEngine;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;
using AdventureQuest.Character;

namespace AdventureQuest.Shop
{
    [RequireComponent(typeof(ObservableShop))]
    public class ShopController : MonoBehaviour
    {

        protected void Start()
        {
            IInventory shopInventory = new Inventory("Wilfred's Weapons");
            shopInventory.Add(new Weapon("Dagger", 3, AbilityRoll.Parse($"1d4 + {Ability.Dexterity}")));
            shopInventory.Add(new Weapon("Sword", 6, AbilityRoll.Parse($"1d6 + {Ability.Strength}")));
            Shop shop = new Shop("Wilfred's Weapons", shopInventory);

            // Shop testShop = new("Wilfred's Weapons", shopInventory);
            GetComponent<ObservableShop>().Shop = shop;
        }
    }    
}