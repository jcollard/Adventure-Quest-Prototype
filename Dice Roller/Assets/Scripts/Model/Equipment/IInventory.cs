using System;
using System.Collections.Generic;
using AdventureQuest.Result;

namespace AdventureQuest.Equipment
{
    public interface IInventory : IObservable<IInventory>
    {
        public string Name { get; }
        public List<IItem> Items { get; }
        public IResult Add(IItem toAdd);
        public IResult Remove(IItem toRemove);
        public void Clear();
        public bool Contains(IItem toCheck);

        public List<IItem> Filter(IEnumerable<Func<IItem, bool>> predicates)
        {
            List<IItem> items = new();
            foreach(IItem item in Items)
            {
                foreach(Func<IItem, bool> pred in predicates)
                {
                    if(pred.Invoke(item))
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}