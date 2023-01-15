using AdventureQuest.Character;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Entity
{
    public static class Enemies
    {

        public static Enemy.Builder Slime = new Enemy.Builder("Slime", "slime-0")
            .AddPortrait("slime-1")
            .TraitRange(Trait.Health, AbilityRoll.Parse($"1d4 + {Ability.Constitution}"))
            .TraitRange(Trait.Stamina, AbilityRoll.Parse($"1d6 + {Ability.Strength}"))
            .AttackRollOneOf(
                AbilityRoll.Parse("1d4"),
                AbilityRoll.Parse("1d6"),
                AbilityRoll.Parse("2d3")
            )
            .DefenseRange(AbilityRoll.Parse($"1d2 + { Ability.Strength }")); 

    }
}