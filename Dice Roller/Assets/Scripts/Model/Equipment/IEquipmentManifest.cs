using System.Collections.Generic;

namespace AdventureQuest.Equipment
{
    public interface IEquipmentManifest
    {
        public bool Equip(IEquipable toEquip, List<EquipmentSlot> slot);
        public bool Unequip(EquipmentSlot type);
        public bool IsEquipped(EquipmentSlot type);
        public IEquipable Equipped(EquipmentSlot type);
    }
}