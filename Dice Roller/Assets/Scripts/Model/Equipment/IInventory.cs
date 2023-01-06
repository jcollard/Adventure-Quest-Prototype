using System.Collections.Generic;
using AdventureQuest.Result;

namespace AdventureQuest.Equipment
{
    public interface IInventory
    {
        public string Name { get; }
        public List<IItem> Items { get; }
        public IResult Add(IItem toAdd);
        public IResult Remove(IItem toRemove);
        public bool Contains(IItem toCheck);
    }
}