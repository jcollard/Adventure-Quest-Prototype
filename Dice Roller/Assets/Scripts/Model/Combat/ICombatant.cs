using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public interface ICombatant : IHasAbilities, IHasTraits, IHasPortriat
    {
        public string Name { get; }
        public int Defense { get; }
        public AbilityRoll AttackRoll { get; }
        public HashSet<ICombatEffect> Effects { get; }
        public Abilities CombatAbilities => Abilities.WithModifiers(Effects);
        public int CombatDefense => ICombatEffect.TotalDefenseBonus(Effects);
        public void AddEffect(ICombatEffect toAdd)
        {
            // TODO: What happens if we do Effects.Add(toAdd) when something
            // already exists. Does it cause it to replace what's in the set?
            // If so, no need to perform this check.
            if (Effects.Contains(toAdd))
            {
                Effects.Remove(toAdd);
            }
            Effects.Add(toAdd);
        }

        public virtual CombatResult Tick()
        {
            CombatResult result = new("Time Passes");
            foreach (ICombatEffect effect in Effects.ToList())
            {
                effect.Tick(this, result);
            }
            return result;
        }
        public virtual CombatResult Attack(ICombatant other)
        {
            CombatResult result = new("Attack!");
            result.Add($"{Name} attacks {other.Name}.");
            int aimResult = AbilityRoll.Parse($"1d20 + {Ability.Dexterity}").Roll(CombatAbilities);
            int dodgeResult = AbilityRoll.Parse($"1d20 + {Ability.Agility}").Roll(other.CombatAbilities);

            if (dodgeResult > aimResult)
            {
                result.Add($"{other.Name} dodges the attack.");
                return result;
            }
            result.Add($"{Name}'s attack connects!");

            int damage = AttackRoll.Roll(CombatAbilities) - other.CombatDefense;

            if (damage <= 0)
            {
                result.Add($"{other.Name} absorbed the blow taking no damage.");
            }
            else
            {
                other.Traits.Get(Trait.Health).Value -= damage;
                result.Add($"{other.Name} took {damage} damage.");
            }
            return result;
        }
    }
}