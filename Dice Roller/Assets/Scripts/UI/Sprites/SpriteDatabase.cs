using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventureQuest.UI
{

    public class SpriteDatabase : MonoBehaviour
    {
        private readonly Dictionary<string, SpriteEntry> _database = new();

        // Lazily loads the database when it is accessed.
        private Dictionary<string, SpriteEntry> Database
        {
            get
            {
                if (_database.Count == 0)
                {
                    foreach (SpriteEntry entry in _entries)
                    {
                        if (_database.ContainsKey(entry.Name)) { throw new System.ArgumentException($"Duplicate key found {entry.Name}."); }
                        _database[entry.Name] = entry;
                    }
                }
                return _database;
            }
        }

        [field: SerializeField]
        private List<SpriteEntry> _entries;
        public int Count => _entries.Count;
        public List<string> Keys => Database.Keys.ToList();
        public SpriteEntry Get(string key) => Database[key];
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