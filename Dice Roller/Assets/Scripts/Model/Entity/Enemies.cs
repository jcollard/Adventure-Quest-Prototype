using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Dice;
using AdventureQuest.Equipment;
using AdventureQuest.Equipment.Armor;

namespace AdventureQuest.Entity
{
    public static class Enemies
    {
        public static Enemy.Builder Slime = new Enemy.Builder("Slime", "slime-0")
            .AddPortrait("slime-1")
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => DicePool.Parse("1d4").Roll() == 4)
                .GoldValue(DicePool.Parse("1d10"))
                .NumberOfItems(DicePool.Parse("1d2"))
                .AddItem(new HealthPotion())
                .Build()
            )
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

        public static Enemy.Builder FlamingSnowman = new Enemy.Builder("Flaming Snowman", "flaming-snowman")
            .TraitRange(Trait.Health, AbilityRoll.Parse("1d6 + 2"))
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => true)
                .GoldValue(DicePool.Parse("1d20"))
                .NumberOfItems(DicePool.Parse("1d6"))
                .AddItem(new Bomb("Ice Bomb"))
                .AddItem(new Bomb("Fire Bomb"))
                .Build()
            )            
            .AttackRoll(AbilityRoll.Parse("1d6"))
            .DefenseRange(AbilityRoll.Parse("1d4"));

        public static Enemy.Builder Mimic = new Enemy.Builder("Mimic", "mimic")
            .TraitRange(Trait.Health, AbilityRoll.Parse("3d4 + 2"))
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => true)
                .GoldValue(DicePool.Parse("1d100"))
                .NumberOfItems(DicePool.Parse("1d6"))
                .AddItem(new HealthPotion())
                .AddItem(new HealthPotion())
                .AddItem(new HealthPotion())
                .AddItem(Weapons.Longsword)
                .AddItem(Weapons.BattleAxe)
                .AddItem(Armors.ChainHelmet)
                .AddItem(Armors.ClothPants)
                .AddItem(Armors.LeatherArmor)
                .AddItem(Armors.LeatherBoots)
                .Build()
            )
            .AttackRoll(AbilityRoll.Parse("2d4"));
        
        public static Enemy.Builder Behemoth = new Enemy.Builder("Behemoth", "behemoth")
            .TraitRange(Trait.Health, AbilityRoll.Parse("10d10"))
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => true)
                .GoldValue(DicePool.Parse("10d20"))
                .NumberOfItems(DicePool.Parse("1d2"))
                .AddItem(new HealthPotion())
                .AddItem(new HealthPotion())
                .Build()
            )
            .AttackRoll(AbilityRoll.Parse("4d4 + 6"));
            

        public static Enemy.Builder DragonHawk = new Enemy.Builder("Dragon Hawk", "dragon-hawk")
            .TraitRange(Trait.Health, AbilityRoll.Parse("2d5 + 4"))
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => true)
                .GoldValue(DicePool.Parse("2d10"))
                .NumberOfItems(DicePool.Parse("1d2"))
                .AddItem(new HealthPotion())
                .AddItem(new HealthPotion())
                .Build()
            )
            .AttackRoll(AbilityRoll.Parse("1d4 + 2"));

        public static Enemy.Builder EarthKing = new Enemy.Builder("EarthKing", "dragon-hawk")
            .TraitRange(Trait.Health, AbilityRoll.Parse("6d6"))
            .LootTable(
                new LootTable.Builder()
                .DropsItems(() => true)
                .GoldValue(DicePool.Parse("5d10"))
                .NumberOfItems(DicePool.Parse("1d2"))
                .AddItem(new HealthPotion())
                .AddItem(Armors.ChainHelmet)
                .Build()
            )
            .AttackRoll(AbilityRoll.Parse("1d20"));

    }
}