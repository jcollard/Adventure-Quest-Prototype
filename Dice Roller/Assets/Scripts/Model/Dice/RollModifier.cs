
using System.Collections.Generic;
using UnityEngine;

using AdventureQuest.Character;

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
    }
}