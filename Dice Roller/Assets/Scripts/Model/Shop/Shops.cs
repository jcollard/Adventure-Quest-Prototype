using AdventureQuest.Equipment;
using AdventureQuest.Equipment.Armor;

namespace AdventureQuest.Shop
{
    public class Shops
    {
        public static Shop CurrentShop { get; set; } = WilfredsWeapons;

        public static Shop WilfredsWeapons
        {
            get
            {
                IInventory shopInventory = new Inventory("Wilfred's Weapons");
                shopInventory.Add(Weapons.Dagger);
                shopInventory.Add(Weapons.ShortSword);
                shopInventory.Add(Weapons.Longsword);
                shopInventory.Add(Weapons.BattleAxe);
                Shop shop = new ("Wilfred's Weapons", shopInventory);
                return shop;
            }
        }

        public static Shop AbdulsArmor
        {
            get
            {
                IInventory shopInventory = new Inventory("Abdul's Armor");
                shopInventory.Add(Armors.ClothPants);
                shopInventory.Add(Armors.LeatherArmor);
                shopInventory.Add(Armors.LeatherBoots);
                shopInventory.Add(Armors.ChainHelmet);
                Shop shop = new ("Abdul's Armor", shopInventory);
                return shop;
            }
        }

        public static Shop AlchemyShop
        {
            get
            {
                IInventory shopInventory = new Inventory("A-1 Alchemy");
                shopInventory.Add(new HealthPotion());
                shopInventory.Add(new Bomb("Fire Bomb"));
                shopInventory.Add(new Bomb("Ice Bomb"));
                shopInventory.Add(new Bomb("Water Bomb"));
                Shop shop = new ("A-1 Alchemy", shopInventory);
                return shop;
            }
        }
    }
}