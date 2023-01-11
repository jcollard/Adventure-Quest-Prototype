
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Equipment.Requirement;
using System.Linq;
using System;

namespace AdventureQuest.Equipment
{
    [Serializable]
    public class Weapon : IEquipable, UnityEngine.ISerializationCallbackReceiver
    {
        private List<IRequirement> _requirements;
        [UnityEngine.SerializeField]
        private List<string> _jsonRequirements;

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

        [field: UnityEngine.SerializeField]
        public string Name { get; private set; }
        
        [field: UnityEngine.SerializeField]
        public string Description { get; private set; }

        [field: UnityEngine.SerializeField]
        public int Cost { get; private set; }

        [field: UnityEngine.SerializeField]
        public AbilityRoll Damage { get; private set; }

        public bool IsTwoHanded { get; }
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

        public void OnBeforeSerialize()
        {
            if (_requirements == null) { return; }
            _jsonRequirements = _requirements.Select(req => req.AsJson).ToList();
        }

        public void OnAfterDeserialize()
        {
            if (_jsonRequirements == null)
            {
                _requirements = new List<IRequirement>() { new WeaponRequirement() };
            }
            else
            {
                _requirements = _jsonRequirements.Select(IRequirement.Deserialize).ToList();
            }
        }

        
    }
}