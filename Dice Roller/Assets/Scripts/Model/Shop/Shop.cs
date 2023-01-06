using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    public class Shop : IShop
    {public static IResult Failure(string message) => new Failure(message);  
        private List<IItem> _items;
        public Shop(List<IItem> items)
        {
            _items = items.ToList();
        }
        public List<IItem> Items => _items.ToList();
        public IResult Purchase(IItem toPurchase, ICharacter shopper)
        {
            if (!_items.Contains(toPurchase)) { return IResult.Failure($"Sorry, I sold my last {toPurchase.Name} yesterday."); }
            if (shopper.Gold < toPurchase.Cost) { return IResult.Failure($"Sorry, you don't have enough gold."); }
            IResult result = shopper.Inventory.Add(toPurchase.Duplicate());
            if (result is Failure) { return result; }
            shopper.Gold -= toPurchase.Cost;
            return IResult.Success($"Thank you for your purchase!");
        }
    }
}