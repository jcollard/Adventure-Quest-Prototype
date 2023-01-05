using System.Collections.Generic;

namespace AdventureQuest.Equipment
{
    public interface IEquipmentManifest
    {
        public Dictionary<EquipmentSlot, IEquipable> Equipped { get; }
        public bool Equip(IEquipable toEquip, List<EquipmentSlot> slot);
        public bool Unequip(EquipmentSlot type);
        public bool IsEquipped(EquipmentSlot type);
    }

    public static class IEquipmentManifestExtensions
    {
        public static bool Equip(this IEquipmentManifest manifest, IEquipable toEquip, EquipmentSlot slot) => manifest.Equip(toEquip, new List<EquipmentSlot>() { slot });
    }
}