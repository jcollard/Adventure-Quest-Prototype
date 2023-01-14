using System.Collections.Generic;
using System;
using System.Linq;

using UnityEngine;
using AdventureQuest.Utils;

namespace AdventureQuest.Trait
{

    [Serializable]
    public class TraitManifest : ISerializationCallbackReceiver
    {
        public static Trait[] AllTraits => (Trait[])System.Enum.GetValues(typeof(Trait));
        private Dictionary<Trait, TraitValue> _traitsLookup;

        [SerializeField]
        private List<TraitValue> _traitValues;

        public TraitManifest(params TraitValue[] traits)
        {
            _traitsLookup = new();
            foreach (TraitValue trait in traits)
            {
                _traitsLookup[trait.Trait] = new TraitValue(trait.Trait, trait.Min, trait.Max, trait.Value);
            }
            foreach (Trait t in AllTraits)
            {
                if (!_traitsLookup.ContainsKey(t))
                {
                    _traitsLookup[t] = new TraitValue(t, 0);
                }
            }
        }

        public TraitValue Get(Trait t) => _traitsLookup[t];

        public void OnBeforeSerialize()
        {
            if (_traitsLookup == null) { return; }
            _traitValues = _traitsLookup.Values.ToList();
        }

        public void OnAfterDeserialize()
        {
            if (_traitValues == null) { return; }
            _traitsLookup = _traitValues.ToDictionary(v => v.Trait, v => v);
        }

        public override bool Equals(object obj)
        {
            return obj is TraitManifest other &&
                   _traitsLookup.DeepCompare(other._traitsLookup);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_traitsLookup);
        }
    }
}