using System.Collections.Generic;
using AdventureQuest.Equipment;
using AdventureQuest.Equipment.Requirement;
using AdventureQuest.Utils;
using System.Linq;
using System;
using UnityEngine;

namespace AdventureQuest.Character.Equipment
{
    [Serializable]
    public class CharacterEquipmentManifest : IEquipmentManifest, ISerializationCallbackReceiver
    {

        // private readonly ICharacter _character;
        private Dictionary<EquipmentSlot, IEquipable> _equipment = new ();

        #region Serialized Fields
        [SerializeField]
        private List<EquipmentSlot> _slots;
        [SerializeField]
        private List<string> _equipped;
        #endregion

        public CharacterEquipmentManifest(ICharacter character)
        {
            if (character == null) { throw new System.ArgumentNullException($"CharacterEquipmentManifest must be registered to a character."); }
            // _character = character;
        }

        public Dictionary<EquipmentSlot, IEquipable> Equipped => _equipment.ToDictionary((pair) => pair.Key, (pair) => pair.Value);

        public virtual bool Equip(IEquipable toEquip, List<EquipmentSlot> slots, ICharacter _character)
        {
            foreach (EquipmentSlot slot in slots)
            {
                if (_equipment.ContainsKey(slot)) { return false; }
                if (!toEquip.Slots.Contains(slot)) { return false; }
            }
            
            foreach (IRequirement requirement in toEquip.Requirements)
            {
                if (!requirement.MeetsRequirement(_character))
                {
                    return false;
                }
            }

            foreach (EquipmentSlot slot in slots)
            {
                _equipment[slot] = toEquip;
            }
            
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is CharacterEquipmentManifest other &&
                   _equipment.DeepCompare(other._equipment);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_equipment, Equipped);
        }

        public bool IsEquipped(EquipmentSlot type) => _equipment.ContainsKey(type);
        
        public bool Unequip(EquipmentSlot type)
        {
            if (_equipment.ContainsKey(type))
            {
                UnequipFromAllSlots(_equipment[type]);
                return true;
            }
            return false;
        }

        private void UnequipFromAllSlots(IEquipable toUnequip)
        {
            HashSet<EquipmentSlot> equippedSlots = new ();
            foreach (KeyValuePair<EquipmentSlot, IEquipable> pair in _equipment)
            {
                if (pair.Value == toUnequip)
                {
                    equippedSlots.Add(pair.Key);
                }
            }

            foreach(EquipmentSlot slot in equippedSlots)
            {
                _equipment.Remove(slot);
            }            
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (_equipment == null) return;
            _slots = new List<EquipmentSlot>();
            _equipped = new List<string>();
            foreach (KeyValuePair<EquipmentSlot, IEquipable> pair in _equipment)
            {
                _slots.Add(pair.Key);
                _equipped.Add(JsonUtility.ToJson(pair.Value));
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (_slots == null || _equipped == null) return;
            _equipment = new Dictionary<EquipmentSlot, IEquipable>();
            for (int ix = 0; ix < _slots.Count; ix++)
            {
                EquipmentSlot key = _slots[ix];
                IEquipable value = (IEquipable)IItem.FromJson(_equipped[ix]);
                _equipment[key] = value;
            }
        }
    }
}
