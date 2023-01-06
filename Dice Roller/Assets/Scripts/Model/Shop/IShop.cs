using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    public interface IShop : IHasInventory
    {
        public string Name { get; }
        public IResult Purchase(IItem toPurchase, ICharacter shopper);
    }
}