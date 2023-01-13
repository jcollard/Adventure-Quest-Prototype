
using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Equipment.Requirement;
using UnityEngine;

namespace AdventureQuest.Equipment
{

    [System.Serializable]
    public abstract class Equipable : IEquipable, ISerializationCallbackReceiver
    {
        private List<IRequirement> _requirements;
        [field: SerializeField]
        private List<string> _jsonRequirements;

        public Equipable(string name, string spriteId, string description, int cost, List<IRequirement> requirements)
        {
            Name = name;
            ItemSpriteID = spriteId;
            Description = description;
            Cost = cost;
            _requirements = requirements.ToList();
        }
        public List<IRequirement> Requirements => _requirements.ToList();

        [field: SerializeField]
        public string ItemSpriteID { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public int Cost { get; private set; }
        
        public abstract HashSet<EquipmentSlot> Slots { get; }
        public virtual string AsJson => JsonUtility.ToJson(this);
        public abstract IItem Duplicate();

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