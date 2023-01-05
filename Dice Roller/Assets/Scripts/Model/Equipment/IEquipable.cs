using AdventureQuest.Character;
namespace AdventureQuest.Equipment
{
    public interface IEquipable : IItem
    {
        public EquipmentType EquipmentType { get; }
    }

}