using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Combat;

namespace AdventureQuest.Entity
{
    public interface ICombatant : IHasAbilities, IHasTraits, IHasPortriat
    {
        public string Name { get; }
        public int Defense { get; }
        public AbilityRoll AttackRoll { get; }

        public virtual CombatResult Attack(ICombatant other)
        {
            CombatResult result = new ();
            result.Add($"{Name} attacks {other.Name}.");
            int aimResult = AbilityRoll.Parse($"1d20 + {Ability.Dexterity}").Roll(Abilities);
            int dodgeResult = AbilityRoll.Parse($"1d20 + {Ability.Agility}").Roll(other.Abilities);

            if (dodgeResult > aimResult)
            {
                result.Add($"{other.Name} dodges the attack.");
                return result;
            }
            result.Add($"{Name}'s attack connects!");

            int damage = AttackRoll.Roll(Abilities) - other.Defense;
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