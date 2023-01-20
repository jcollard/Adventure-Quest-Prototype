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
        
        public static Enemy.Builder DarkKnight = new Enemy.Builder("Dark Knight", "dark-knight-0")
            .AddPortrait("dark-knight-1")
            .TraitRange(Trait.Health, AbilityRoll.Parse("1d8 + 5"))
            .TraitRange(Trait.Stamina, AbilityRoll.Parse("4d4 + 4"))
            .AttackRoll(AbilityRoll.Parse("1d12"))
            .DefenseRange(AbilityRoll.Parse($"2d3"));
        
        public static Enemy.Builder StrawManOfDoom = new Enemy.Builder("Straw Man of Doom", "straw-man")
            .TraitRange(Trait.Health, AbilityRoll.Parse("1d8 + 5"))
            .TraitRange(Trait.Stamina, AbilityRoll.Parse("4d4 + 4"))
            .Abilities(
                new Abilities.Builder().SetScore(Ability.Dexterity, 30).Build()
            )
            .AttackRoll(AbilityRoll.Parse("10d12"))
            .DefenseRange(AbilityRoll.Parse($"2d3"));

    }
}