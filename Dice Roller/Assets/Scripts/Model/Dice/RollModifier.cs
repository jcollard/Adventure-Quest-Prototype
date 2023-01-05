
using System.Collections.Generic;
using UnityEngine;

using AdventureQuest.Character;
using System.Linq;

namespace AdventureQuest.Dice
{
    [System.Serializable]
    public class RollModifier
    {
        [SerializeField]
        private readonly List<Ability> _abilityModifiers = new ();

        public RollModifier(int modifier, params Ability[] abilities)
        {
            if (modifier < 0) { throw new System.ArgumentException($"Roll modifiers must be additive but the modifier was {modifier}."); }

            Modifier = modifier;
            foreach (Ability ability in abilities)
            {
                _abilityModifiers.Add(ability);
            }
        }

        public int Modifier { get; }
        public List<Ability> AbilityModifiers 
        { 
            get
            {
                List<Ability> abilities = new ();
                foreach (Ability ability in _abilityModifiers)
                {
                    abilities.Add(ability);
                }
                return abilities;
            }            
        }

        public int ModifyWith(Abilities abilities)
        {
            int total = Modifier;
            foreach (Ability ability in AbilityModifiers)
            {
                total += abilities.Score(ability).Score;
            }
            return total;
        }

        public static RollModifier Parse(string modifier)
        {
            if (!IsParseable(modifier)) { throw new System.FormatException($"Could not parse \"{modifier}\" as a RollModifier."); }
            string[] tokens = modifier.Trim().Split("+");
            int valueComponent = 0;
            List<Ability> abilities = new ();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    valueComponent += value;
                }
                else
                {
                    abilities.Add(ParseAbilityUnit(token));
                }
            }
            return new RollModifier(valueComponent, abilities.ToArray());
        }

        public static bool IsParseable(string modifier)
        {
            if (modifier == null) { return false; }
            string[] tokens = modifier.Trim().Split("+");
            foreach (string token in tokens)
            {
                if (!IsUnitParseable(token)) { return false; }
            }
            return true;
        }

        private static Ability ParseAbilityUnit(string modifier) => System.Enum.Parse<Ability>(modifier, true);

        // 5 + DEX + AGI
        private static bool IsUnitParseable(string modifier)
        {
            modifier = modifier.Trim().ToLower();
            if (int.TryParse(modifier, out int value) && value > 0)
            {
                return true;
            }
            return System.Enum.TryParse(modifier, true, out Ability _);
        }
    }
}