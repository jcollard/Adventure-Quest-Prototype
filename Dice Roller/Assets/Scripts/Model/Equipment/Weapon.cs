
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Equipment.Requirement;
using System.Linq;
using System;

namespace AdventureQuest.Equipment
{
    [Serializable]
    public class Weapon : Equipable, UnityEngine.ISerializationCallbackReceiver
    {
        public Weapon(string name, string spriteId, string description, int cost, AbilityRoll damage) : 
            this(name, spriteId, description, cost, damage, new List<IRequirement>() { new WeaponRequirement() }) { }

        public Weapon(string name, string spriteId, string description, int cost, AbilityRoll damage, List<IRequirement> requirements) :
            base(name, spriteId, description, cost, requirements)
        {
            Damage = damage;
        }
        [field: UnityEngine.SerializeField]
        public AbilityRoll Damage { get; private set; }
        [field: UnityEngine.SerializeField]
        public override string ClassInformation { get; protected set; } = "Weapon";

        public bool IsTwoHanded { get; }
        public override HashSet<EquipmentSlot> Slots => new() { EquipmentSlot.LeftHand, EquipmentSlot.RightHand };

        public override IItem Duplicate() => new Weapon(Name, ItemSpriteID, Description, Cost, Damage, Requirements);

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