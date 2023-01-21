using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Character;
using AdventureQuest.Character.Dice;
using AdventureQuest.Combat;
using AdventureQuest.Dice;
using AdventureQuest.Equipment;
using AdventureQuest.Utils;

namespace AdventureQuest.Entity
{
    public class Enemy : ICombatant
    {
        private Enemy()
        {

        }

        public string Name { get; private set; }
        public int Defense { get; private set; }
        public AbilityRoll AttackRoll { get; private set; }
        public Abilities Abilities { get; private set; }
        public TraitManifest Traits { get; private set; }
        public string PortraitSpriteKey { get; private set; }
        public Loot Loot { get; private set; }
        public HashSet<ICombatEffect> Effects { get; } = new ();
        
        public class Builder
        {
            private string _name;
            private int _defense = 0;
            private AbilityRoll _defenseRoll;
            private List<AbilityRoll> _attackRolls = new() { AbilityRoll.Parse($"1d4 + {Ability.Strength}") };
            private Abilities _abilities = Character.Abilities.Roll();
            private Dictionary<Trait, AbilityRoll> _traits;
            private List<string> _portriatOptions;
            private ILootTable _lootTable = new LootTable.Builder().GoldValue(DicePool.Parse("1d6")).Build();

            public Builder(string name, string portraitSpriteKey)
            {
                _name = name;
                _portriatOptions = new List<string>() { portraitSpriteKey };
                _traits = new Dictionary<Trait, AbilityRoll>();
                _traits[Trait.Health] = AbilityRoll.Parse($"1d6 + {Ability.Constitution}");
                _traits[Trait.Stamina] = AbilityRoll.Parse($"1d6 + {Ability.Strength}");
            }

            /// <summary>
            /// Sets the defense of the Enemy to <paramref name="value"/>. For convenience, this
            /// method returns the builder that was modified.
            /// </summary>
            public Builder Defense(int value) => SetRef(ref _defense, value);
            public Builder DefenseRange(AbilityRoll value) => SetRef(ref _defenseRoll, value);
            public Builder LootTable(ILootTable value) => SetRef(ref _lootTable, value);
            public Builder AttackRoll(AbilityRoll value) => AttackRollOneOf(value);

            public Builder TraitRange(Trait trait, AbilityRoll roll) 
            {
                _traits[trait] = roll;
                return this;
            }

            public Builder AddPortrait(string value)
            {
                _portriatOptions.Add(value);
                return this;
            }            
            public Builder AttackRollOneOf(params AbilityRoll[] values)
            {
                _attackRolls = values.ToList();
                return this;
            }
            public Builder Abilities(Abilities value) => SetRef(ref _abilities, value);


            public Enemy Build()
            {
                if (_defenseRoll != null) { _defense = _defenseRoll.Roll(_abilities); }
                TraitManifest traitManifest = new ();
                foreach (KeyValuePair<Trait, AbilityRoll> trait in _traits)
                {
                    traitManifest.Get(trait.Key).Max = System.Math.Max(1, trait.Value.Roll(_abilities));
                    traitManifest.Get(trait.Key).Value = traitManifest.Get(trait.Key).Max;
                }
                
                return new Enemy()
                {
                    Name = _name,
                    Defense = _defense,
                    AttackRoll = _attackRolls.Random(),
                    Abilities = _abilities,
                    Traits = traitManifest,
                    PortraitSpriteKey = _portriatOptions.Random(),
                    Loot = _lootTable.Roll()                    
                };

            }

            private Builder SetRef<T>(ref T field, T value)
            {
                field = value;
                return this;
            }


        }
    }
}