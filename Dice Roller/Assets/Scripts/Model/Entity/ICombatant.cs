using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Entity
{
    public interface ICombatant : IHasAbilities, IHasTraits, IHasPortriat
    {
        public string Name { get; }
        public int Defense { get; }
        public AbilityRoll AttackRoll { get; }

        public virtual AttackResult Attack(ICombatant other)
        {
            List<string> outcomes = new () { $"{Name} attacks {other.Name}." };
            int aimResult = AbilityRoll.Parse($"1d20 + {Ability.Dexterity}").Roll(Abilities);
            int dodgeResult = AbilityRoll.Parse($"1d20 + {Ability.Agility}").Roll(other.Abilities);

            if (dodgeResult > aimResult)
            {
                outcomes.Add($"{other.Name} dodges the attack.");
                return new AttackResult(this, other, string.Join("\n", outcomes));
            }
            outcomes.Add($"{Name}'s attack connects!");

            int damage = AttackRoll.Roll(Abilities) - other.Defense;
            if (damage <= 0)
            {
                outcomes.Add($"{other.Name} absorbed the blow taking no damage.");
            }
            else
            {
                other.Traits.Get(Trait.Health).Value -= damage;
                outcomes.Add($"{other.Name} took {damage} damage.");
            }
            return new AttackResult(this, other, string.Join("\n", outcomes));
        }
    }
}