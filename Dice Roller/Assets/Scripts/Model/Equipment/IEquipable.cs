using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment.Requirement;

namespace AdventureQuest.Equipment
{
    public interface IEquipable : IItem
    {
        public HashSet<EquipmentSlot> Slots { get; }
        public List<IRequirement> Requirements { get; }

    }
}