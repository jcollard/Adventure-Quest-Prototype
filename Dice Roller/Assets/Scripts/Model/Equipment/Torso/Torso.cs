
using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Equipment.Requirement;

namespace AdventureQuest.Equipment.Torso
{

    public class Torso : Equipable
    {
        private List<IRequirement> _requirements;

        public Torso(string name, string spriteId, string description, int cost) : 
            this(name, spriteId, description, cost, new List<IRequirement>() {}) {}

        public Torso(string name, string spriteId, string description, int cost, List<IRequirement> requirements) 
            : base(name, spriteId, description, cost, requirements) 
        { }

        public override HashSet<EquipmentSlot> Slots => new () { EquipmentSlot.Torso };
        public override IItem Duplicate() => new Torso(Name, ItemSpriteID, Description, Cost, _requirements);
    }

}