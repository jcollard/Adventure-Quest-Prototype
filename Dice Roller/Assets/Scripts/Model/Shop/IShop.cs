using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment;
using AdventureQuest.Result;

namespace AdventureQuest.Shop
{
    public interface IShop
    {
        public List<IItem> Items { get; }
        public IResult Purchase(IItem toPurchase, ICharacter shopper);
    }
}