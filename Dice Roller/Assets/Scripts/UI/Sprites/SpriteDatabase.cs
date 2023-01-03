using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventureQuest.UI
{

    public class SpriteDatabase : MonoBehaviour
    {
        private readonly Dictionary<string, SpriteEntry> _database = new();

        [field: SerializeField]
        private List<SpriteEntry> _entries;

        protected void Start()
        {
            foreach (SpriteEntry entry in _entries)
            {
                if (_database.ContainsKey(entry.Name)) { throw new System.ArgumentException($"Duplicate key found {entry.Name}."); }
                _database[entry.Name] = entry;
            }
        }

        public int Count => _entries.Count;
        public List<string> Keys => _database.Keys.ToList();
        public SpriteEntry Get(string key) => _database[key];
        public SpriteEntry Get(int ix) => _entries[ix];


    }

    [System.Serializable]
    public class SpriteEntry
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public Sprite Sprite { get; private set; }

        public SpriteEntry(string name, Sprite sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }

}