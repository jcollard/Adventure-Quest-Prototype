
using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Equipment.Requirement;
using UnityEngine;

namespace AdventureQuest.Equipment.Armor
{
    [System.Serializable]
    public class Armor : Equipable
    {
        [field: SerializeField]
        private EquipmentSlot _slot;

        public Armor(string name, string spriteId, string description, int cost, int defense, EquipmentSlot slot) : 
            this(name, spriteId, description, cost, defense, slot, new List<IRequirement>() {}) {}

        public Armor(string name, string spriteId, string description, int cost, int defense, EquipmentSlot slot, List<IRequirement> requirements) 
            : base(name, spriteId, description, cost, requirements) 
        { 
            Defense = defense;
            _slot = slot;
        }

        [field: SerializeField]
        public int Defense { get; private set; }
        [field: SerializeField]
        public override string ClassInformation { get; protected set; } = "Armor";

        public override HashSet<EquipmentSlot> Slots => new () { _slot };
        public override IItem Duplicate() => new Armor(Name, ItemSpriteID, Description, Cost, Defense, _slot, Requirements);

        public override bool Equals(object obj)
        {
            return obj is Armor armor &&
                   Name == armor.Name &&
                   Description == armor.Description &&
                   Cost == armor.Cost &&
                   Defense == armor.Defense &&
                   _slot == armor._slot;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Name, Description, Cost, Defense, _slot);
        }
    }

}