using System;
using System.Linq;
using System.Collections.Generic;
using AdventureQuest.Character.Equipment;
using AdventureQuest.Equipment;
using AdventureQuest.Entity;
using UnityEngine;
using AdventureQuest.Equipment.Armor;
using AdventureQuest.Character.Dice;
using AdventureQuest.Combat;

namespace AdventureQuest.Character
{
    [Serializable]
    public class PlayerCharacter : ICharacter, ISerializationCallbackReceiver
    {
        [field: SerializeField]
        private int _gold;
        [field: SerializeField]
        private string _equipmentJson;
        [field: SerializeField]
        private string _inventoryJson;

        public PlayerCharacter(string name, Abilities abilities, TraitManifest traits, string portraitSpriteKey)
        {
            if (name == null || abilities == null || traits == null || portraitSpriteKey == null)
            {
                throw new ArgumentNullException();
            }
            Name = name;
            Abilities = abilities;
            PortraitSpriteKey = portraitSpriteKey;
            Traits = traits;
            InitSerializedFields();
        }

        public event Action<ICharacter> OnChange;

        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string PortraitSpriteKey { get; private set; }
        [field: SerializeField]
        public Abilities Abilities { get; private set; }
        [field: SerializeField]
        public TraitManifest Traits { get; private set; }
        public string AsJson => Encode(this);
        public IEquipmentManifest Equipment { get; private set; }
        public IInventory Inventory { get; private set; }
        public HashSet<ICombatEffect> Effects { get; private set; }

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

        #region ICombatant Implementation

        public int Defense
        {
            get
            {
                return Equipment.Equipped.Values
                    .Where(equippable => equippable is Armor)
                    .Select(equippable => (Armor)equippable)
                    .Sum(armor => armor.Defense);
            }
        }

        public AbilityRoll AttackRoll
        {
            get
            {
                IEquipable equipable = Equipment.Equipped.Values.FirstOrDefault(equipable => equipable is Weapon);
                if (equipable != null) { return ((Weapon)equipable).Damage; }
                return AbilityRoll.Parse($"1d4 + {Ability.Strength}");
            }
        }

        #endregion

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

        public static string Encode(PlayerCharacter character) => JsonUtility.ToJson(character);

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
            if (obj is PlayerCharacter other)
            {
                return
                   _gold == other._gold &&
                   Name == other.Name &&
                   PortraitSpriteKey == other.PortraitSpriteKey &&
                   Abilities.Equals(other.Abilities) &&
                   Inventory.Equals(other.Inventory) &&
                   Equipment.Equals(other.Equipment) &&
                   Traits.Equals(other.Traits);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_gold, Name, PortraitSpriteKey, Abilities, Equipment, Inventory, Gold, Traits);
        }

        private void InitSerializedFields()
        {
            Inventory = _inventoryJson == null ? new Inventory($"{Name}'s Inventory") : JsonUtility.FromJson<Inventory>(_inventoryJson);
            Equipment = _equipmentJson == null ? new CharacterEquipmentManifest(this) : JsonUtility.FromJson<CharacterEquipmentManifest>(_equipmentJson);
            Effects = new();
        }
    }
}