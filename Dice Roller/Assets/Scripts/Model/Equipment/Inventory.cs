using System.Collections.Generic;
using AdventureQuest.Result;
using AdventureQuest.Utils;
using System.Linq;
using System;
using UnityEngine;
using AdventureQuest.Json;

namespace AdventureQuest.Equipment
{
    public class Inventory : IInventory, UnityEngine.ISerializationCallbackReceiver
    {
        private List<IItem> _items;
        [SerializeField]
        private List<string> _serializedItems;
        public event Action<IInventory> OnChange;

        public Inventory(string name)
        {
            _items = new ();
            Name = name;
        }

        [field: SerializeField]
        public string Name { get; private set; }
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

        public void Clear()
        {
            _items.Clear();
            OnChange?.Invoke(this);
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

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (_items == null) { return; }
            _serializedItems = _items.Select(IItem.ToJson).ToList();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (_serializedItems == null) { return; }
            _items = _serializedItems.Select(IItem.FromJson).ToList();
        }
    }
}