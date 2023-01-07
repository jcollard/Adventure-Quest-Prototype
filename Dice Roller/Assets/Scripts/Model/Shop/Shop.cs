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

        public IResult Sell(IItem toSell, ICharacter shopper)
        {
            if (!shopper.Inventory.Contains(toSell)) { return IResult.Failure($"You don't own that! What are you trying to pull here?"); }
            IResult result = shopper.Inventory.Remove(toSell);
            if (result is Failure) { return result; }            
            int value = EvaluateItem(toSell, shopper).Value;
            shopper.Gold += value;
            return IResult.Success($"Nice doin' buisness with ya!");
        }

        public SaleProposal EvaluateItem(IItem toSell, ICharacter shopper) 
        {
            int value = toSell.Cost/2;
            return new SaleProposal(
                $"Selling {toSell.Name}", 
                $"Hmmm... that {toSell.Name} looks a litte worn out. But, I'll give you {value} gold for it. What do you think?", 
                value);
        }
    }
}