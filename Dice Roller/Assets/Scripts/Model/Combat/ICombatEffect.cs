using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Entity;
using AdventureQuest.Utils;
using System.Linq;

namespace AdventureQuest.Combat
{
    public interface ICombatEffect
    {
        public string Name { get; }
        /// <summary>
        /// The number of full combat rounds that this buff
        /// remains active on the ICombatant
        /// </summary>
        public int Duration { get; protected set; }
        public virtual int DefenseBonus => 0;
        public virtual Dictionary<Ability, int> AbilityModifiers => new();
        public virtual Dictionary<Trait, int> TraitModifiers => new();

        public string EndMessage(ICombatant combatant);

        /// <summary>
        /// Tick is called during combat once per round when the character is activated.
        /// </summary>
        public virtual void Tick(ICombatant combatant, CombatResult result)
        {
            Duration--;
            if (Duration <= 0)
            {
                combatant.Effects.Remove(this);
                result.Add(EndMessage(combatant));
            }
        }

        public static int TotalDefenseBonus(HashSet<ICombatEffect> effects) => effects.Sum(e => e.DefenseBonus);

        /// <summary>
        /// Calculates the sum of all ability modifiers from the given list of effects.
        /// </summary>
        /// <param name="effects">A list of ICombatEffect to be used in the calculation.</param>
        /// <returns>A dictionary of Ability and int values representing the sum of all ability modifiers.</returns>
        public static Dictionary<Ability, int> AbilityModifierSum(HashSet<ICombatEffect> effects) => effects.Select(e => e.AbilityModifiers).SumHistogram();
        public static Dictionary<Trait, int> TraitModifierSum(HashSet<ICombatEffect> effects) => effects.Select(e => e.TraitModifiers).SumHistogram();
    }
}