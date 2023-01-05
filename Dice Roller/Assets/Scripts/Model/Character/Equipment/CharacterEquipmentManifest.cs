using System.Collections.Generic;
using AdventureQuest.Equipment;

namespace AdventureQuest.Character.Equipment
{
    public class CharacterEquipmentManifest : IEquipmentManifest
    {

        private readonly ICharacter _character;
        private Dictionary<EquipmentSlot, IEquipable> _equipment = new ();

        public CharacterEquipmentManifest(ICharacter character)
        {
            if (character == null) { throw new System.ArgumentNullException($"CharacterEquipmentManifest must be registered to a character."); }
            _character = character;
        }
        
        public virtual bool Equip(IEquipable toEquip, List<EquipmentSlot> slots)
        {
            foreach (EquipmentSlot slot in toEquip.Slots)
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

            foreach (EquipmentSlot slot in toEquip.Slots)
            {
                _equipment[slot] = toEquip;
            }
            
            return true;
        }

        public IEquipable Equipped(EquipmentSlot type)
        {
            if (!IsEquipped(type)) { throw new System.InvalidOperationException($"No equipment in equipment slot: {type}."); }
            return _equipment[type];
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

    }
}
