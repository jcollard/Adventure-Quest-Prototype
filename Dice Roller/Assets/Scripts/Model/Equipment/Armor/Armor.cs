
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

        public override HashSet<EquipmentSlot> Slots => new () { _slot };
        public override IItem Duplicate() => new Armor(Name, ItemSpriteID, Description, Cost, Defense, _slot, Requirements);
    }

}