using System;
using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character.Equipment;
using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.Character
{
    [System.Serializable]
    public class PlayerCharacter : ICharacter, ISerializationCallbackReceiver
    {
        [field: SerializeField]
        private int _gold;
        [field: SerializeField]
        private string _equipmentJson;
        [field: SerializeField]
        private string _inventoryJson;
        
        public PlayerCharacter(string name, Abilities abilities, string portraitSpriteKey)
        {
            if (name == null || abilities == null || portraitSpriteKey == null)
            {
                throw new System.ArgumentNullException();
            }
            Name = name;
            Abilities = abilities;
            PortraitSpriteKey = portraitSpriteKey;
            InitSerializedFields();
        }

        public event Action<ICharacter> OnChange;

        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string PortraitSpriteKey { get; private set; }
        [field: SerializeField]
        public Abilities Abilities { get; private set; }
        public IEquipmentManifest Equipment { get; private set; }
        public IInventory Inventory { get; private set; }
        
        public int Gold 
        { 
            get => _gold; 
            set 
            {
                if (value < 0) 
                {  
                    Debug.Assert(value >= 0, $"Attempted to set PlayerCharacter.Gold to a value less than 0. {value}");
                }
                _gold = Mathf.Max(value, 0);
                OnChange?.Invoke(this);
            }
        }

        public static bool Store(PlayerCharacter character)
        {
            string encoded = Encode(character);
            PlayerPrefs.SetString("character", encoded);
            return true;
        }

        public static PlayerCharacter Restore()
        {
            if (!PlayerPrefs.HasKey("character")) { throw new System.InvalidOperationException("No Player Character found."); }
            string encoded = PlayerPrefs.GetString("character");
            return Decode(encoded);
        }

        public static string Encode(PlayerCharacter character)
        {
            string asJson = JsonUtility.ToJson(character);
            return asJson;
        }

        public static PlayerCharacter Decode(string json)
        {
            try
            {
                PlayerCharacter loaded = JsonUtility.FromJson<PlayerCharacter>(json);
                // TODO: Validate loaded is in a legal state
                return loaded;
            }
            catch 
            {
                // TODO: Use correct exceptions / error reporting
                throw new System.IO.InvalidDataException($"Could not load PlayerCharacter.");
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (Equipment == null || Inventory == null) { return; }
            _equipmentJson = JsonUtility.ToJson(Equipment);
            _inventoryJson = JsonUtility.ToJson(Inventory);            
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            InitSerializedFields();
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerCharacter other &&
                   _gold == other._gold &&
                   Name == other.Name &&
                   PortraitSpriteKey == other.PortraitSpriteKey &&
                   Abilities.Equals(other.Abilities) &&
                   Inventory.Equals(other.Inventory) &&
                   Equipment.Equals(other.Equipment);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_gold, Name, PortraitSpriteKey, Abilities, Equipment, Inventory, Gold);
        }

        private void InitSerializedFields()
        {
            Inventory = _inventoryJson == null ? new Inventory($"{Name}'s Inventory") : JsonUtility.FromJson<Inventory>(_inventoryJson);
            Equipment = _equipmentJson == null ? new CharacterEquipmentManifest(this) : JsonUtility.FromJson<CharacterEquipmentManifest>(_equipmentJson);
        }
    }
}