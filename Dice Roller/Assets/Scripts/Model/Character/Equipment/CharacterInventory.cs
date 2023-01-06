using System.Collections.Generic;
using AdventureQuest.Result;
using AdventureQuest.Equipment;
using System.Linq;

namespace AdventureQuest.Character.Equipment
{
    public class CharacterInventory : IInventory
    {
        private List<IItem> _items;

        public CharacterInventory()
        {
            _items = new ();
        }

        public List<IItem> Items => _items.ToList();
        public IResult Add(IItem toAdd)
        {
            if (toAdd == null) { throw new System.ArgumentNullException(); }
            _items.Add(toAdd);
            return IResult.Success();
        }
        public IResult Remove(IItem toRemove)
        {
            if (!_items.Remove(toRemove)) { IResult.Failure($"You don't have a {toRemove.Name}."); }
            return IResult.Success();
        }
    
        public bool Contains(IItem toCheck) => _items.Contains(toCheck);
    }
}