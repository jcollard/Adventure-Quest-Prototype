
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Equipment.Requirement;
using System.Linq;

namespace AdventureQuest.Equipment
{
    public class Weapon : IEquipable
    {
        private List<IRequirement> _requirements;

        public Weapon(string name, int cost, AbilityRoll damage) : 
            this(name, cost, damage, new List<IRequirement>() { new WeaponRequirement() }) { }

        public Weapon(string name, int cost, AbilityRoll damage, List<IRequirement> requirements)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            _requirements = requirements.ToList();
        }

        public string Name { get; }
        public int Cost { get; }
        public bool IsTwoHanded { get; }
        public AbilityRoll Damage { get; }
        public HashSet<EquipmentSlot> Slots => new() { EquipmentSlot.LeftHand, EquipmentSlot.RightHand };
        public List<IRequirement> Requirements => _requirements.ToList();

    }
}