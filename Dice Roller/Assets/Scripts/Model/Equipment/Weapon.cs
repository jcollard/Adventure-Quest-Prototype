
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Equipment.Requirement;
using System.Linq;
using System;

namespace AdventureQuest.Equipment
{
    public class Weapon : IEquipable
    {
        private List<IRequirement> _requirements;

        public Weapon(string name, string description, int cost, AbilityRoll damage) : 
            this(name, description, cost, damage, new List<IRequirement>() { new WeaponRequirement() }) { }

        public Weapon(string name, string description, int cost, AbilityRoll damage, List<IRequirement> requirements)
        {
            Name = name;
            Description = description;
            Cost = cost;
            Damage = damage;
            _requirements = requirements.ToList();
        }

        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }
        public bool IsTwoHanded { get; }
        public AbilityRoll Damage { get; }
        public HashSet<EquipmentSlot> Slots => new() { EquipmentSlot.LeftHand, EquipmentSlot.RightHand };
        public List<IRequirement> Requirements => _requirements.ToList();

        public virtual IItem Duplicate() => new Weapon(Name, Description, Cost, Damage, Requirements);

        public override bool Equals(object obj)
        {
            return obj is Weapon weapon &&
                   Name == weapon.Name &&
                   Description == weapon.Description &&
                   Cost == weapon.Cost;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Cost);
        }
    }
}