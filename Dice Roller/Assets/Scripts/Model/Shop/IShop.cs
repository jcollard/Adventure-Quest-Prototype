using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    public interface IShop
    {
        public string Name { get; }
        public IInventory Inventory { get; }
        public IResult Purchase(IItem toPurchase, ICharacter shopper);
    }
}