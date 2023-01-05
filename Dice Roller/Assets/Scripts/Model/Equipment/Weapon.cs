
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Equipment
{
    public class Weapon : IEquipable
    {
        public Weapon(string name, int cost, AbilityRoll damage)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
        }

        public string Name { get; }
        public int Cost { get; }
        public AbilityRoll Damage { get; }
        public EquipmentType EquipmentType => EquipmentType.Weapon;

    }
}