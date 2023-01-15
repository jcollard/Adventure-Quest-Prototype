using AdventureQuest.Character;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Entity
{
    public class Enemy : ICombatant
    {
        private Enemy(string name, int defense, AbilityRoll attackRoll, Abilities abilities, TraitManifest traits, string portraitSpriteKey)
        {
            Name = name;
            Defense = defense;
            AttackRoll = attackRoll;
            Abilities = abilities;
            Traits = traits;            
            PortraitSpriteKey = portraitSpriteKey;
        }

        public string Name { get; }
        public int Defense { get; }
        public AbilityRoll AttackRoll { get; }
        public Abilities Abilities { get; }
        public TraitManifest Traits { get; }
        public string PortraitSpriteKey { get; }

        public class Builder
        {
            private string _name;
            private int _defense = 0;
            private AbilityRoll _attackRoll = AbilityRoll.Parse($"1d4 + {Ability.Strength}");
            private Abilities _abilities = Character.Abilities.Roll();
            private TraitManifest _traits;
            private string _portraitSpriteKey;
            
            public Builder(string name, int hp, int stamina, string portraitSpriteKey)
            {
                _name = name;
                _portraitSpriteKey = portraitSpriteKey;
                _traits = new TraitManifest(
                    new TraitValue(Trait.Health, hp),
                    new TraitValue(Trait.Stamina, stamina)
                );
            }

            public Builder Defense(int value) => SetRef(ref _defense, value);
            public Builder AttackRoll(AbilityRoll value) => SetRef(ref _attackRoll, value);
            public Builder Abilities(Abilities value) => SetRef(ref _abilities, value);
            public Enemy Build() => new Enemy(_name, _defense, _attackRoll, _abilities, _traits, _portraitSpriteKey);

            private Builder SetRef<T>(ref T field, T value)
            {
                field = value;
                return this;
            }

            
        }
    }
}