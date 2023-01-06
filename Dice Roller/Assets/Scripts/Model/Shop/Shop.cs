using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    public class Shop : IShop
    {
        public Shop(string name, IInventory inventory)
        {
            Name = name;
            Inventory = inventory;
        }
        public string Name { get; }
        public IInventory Inventory { get; }
        public IResult Purchase(IItem toPurchase, ICharacter shopper)
        {
            if (!Inventory.Contains(toPurchase)) { return IResult.Failure($"Sorry, I sold my last {toPurchase.Name} yesterday."); }
            if (shopper.Gold < toPurchase.Cost) { return IResult.Failure($"Sorry, you don't have enough gold."); }
            IResult result = shopper.Inventory.Add(toPurchase.Duplicate());
            if (result is Failure) { return result; }
            shopper.Gold -= toPurchase.Cost;
            return IResult.Success($"Thank you for your purchase!");
        }
    }
}