using System;
using UnityEngine;

namespace AdventureQuest.Trait
{
    [Serializable]
    public class TraitValue
    {
        [SerializeField]
        private int _value;

        public TraitValue(Trait trait, int max) : this(trait, 0, max, max) { }

        public TraitValue(Trait trait, int min, int max, int value)
        {
            Trait = trait;
            Min = min;
            Max = max;
            Value = value;
        }

        [field: SerializeField]
        public Trait Trait { get; private set; }
        [field: SerializeField]
        public int Max { get; set; }
        [field: SerializeField]
        public int Min { get; set; }

        public int Value
        {
            get => _value;
            set => _value = Math.Clamp(value, Min, Max);
        }

        public override bool Equals(object obj)
        {
            return obj is TraitValue other &&
                   Trait == other.Trait &&
                   Min == other.Min &&
                   Max == other.Max &&
                   Value == other.Value;
        }

        public override int GetHashCode() => HashCode.Combine(Trait, Min, Max, Value);
    }
}