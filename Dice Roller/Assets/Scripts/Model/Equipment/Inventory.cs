using System.Collections.Generic;
using AdventureQuest.Result;
using AdventureQuest.Utils;
using System.Linq;
using System;

namespace AdventureQuest.Equipment
{
    public class Inventory : IInventory
    {
        private List<IItem> _items;
        public event Action<IInventory> OnChange;

        public Inventory(string name)
        {
            _items = new ();
            Name = name;
        }

        public string Name { get; }
        public List<IItem> Items => _items.ToList();
        public IResult Add(IItem toAdd)
        {
            if (toAdd == null) { throw new System.ArgumentNullException(); }
            _items.Add(toAdd);
            OnChange?.Invoke(this);
            return IResult.Success();
        }
        public IResult Remove(IItem toRemove)
        {
            if (!_items.Remove(toRemove)) { IResult.Failure($"You don't have a {toRemove.Name}."); }
            OnChange?.Invoke(this);
            return IResult.Success();
        }
    
        public bool Contains(IItem toCheck) => _items.Contains(toCheck);

        public override bool Equals(object obj)
        {
            return obj is Inventory other &&
                   Name == other.Name &&
                   _items.DeepCompare(other._items);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_items, Name);
        }
    }
}