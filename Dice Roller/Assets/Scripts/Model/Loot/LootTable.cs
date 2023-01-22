
using System.Collections.Generic;
using AdventureQuest.Dice;
using AdventureQuest.Utils;

namespace AdventureQuest.Equipment
{
    public class LootTable : ILootTable
    {
        private IRollable _goldValue;
        private IRollable _numberOfItems;
        private List<IItem> _items;
        private System.Func<bool> _dropsItems;
        private LootTable() {}
        public Loot Roll()
        {
            if(_dropsItems.Invoke())
            {
                return DropItems();
            }
            return new Loot(_goldValue.Roll());   
        }

        private Loot DropItems()
        {
            int totalValue = _goldValue.Roll();
            List<IItem> lootItems = new();
            List<IItem> possibleLoot = new(_items);
            int itemCount = _numberOfItems == null ? 0 : _numberOfItems.Roll();
            
            possibleLoot.RemoveAll((item) => item.Cost > totalValue);

            while (possibleLoot.Count > 0 && itemCount > 0)
            {
                IItem toGive = possibleLoot.Random();
                lootItems.Add(toGive);
                possibleLoot.Remove(toGive);
                totalValue -= toGive.Cost;
                possibleLoot.RemoveAll((item) => item.Cost > totalValue);
                itemCount--;
            }
            return new Loot(totalValue, lootItems);
        }

        public class Builder
        {
            private IRollable _goldValue;
            private IRollable _numberOfItems = null;
            private System.Func<bool> _dropsItems = () => false;
            private readonly List<IItem> _items = new ();
            public Builder GoldValue(IRollable rollable)
            {
                _goldValue = rollable;
                return this;
            }
            public Builder DropsItems(System.Func<bool> dropsItems)
            {
                _dropsItems = dropsItems;
                return this;
            }

            public Builder NumberOfItems(IRollable itemRoll)
            {
                _numberOfItems = itemRoll;
                return this;
            }

            public Builder AddItem(IItem item)
            {
                _items.Add(item.Duplicate());
                return this;
            }

            public ILootTable Build()
            {
                return new LootTable() 
                { 
                    _goldValue = this._goldValue,
                    _numberOfItems = this._numberOfItems,
                    _items = this._items,
                    _dropsItems = this._dropsItems
                };
            }
        }
    }
}