using System.Collections.Generic;

using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{
    public interface IEquipmentManifest
    {
        public Dictionary<EquipmentSlot, IEquipable> Equipped { get; }
        public bool Equip(IEquipable toEquip, List<EquipmentSlot> slot, ICharacter wearer);
        public bool Unequip(EquipmentSlot type);
        public bool IsEquipped(EquipmentSlot type);
    }

    public static class IEquipmentManifestExtensions
    {
        public static bool Equip(this IEquipmentManifest manifest, IEquipable toEquip, EquipmentSlot slot, ICharacter wearer) => manifest.Equip(toEquip, new List<EquipmentSlot>() { slot }, wearer);
    }
}