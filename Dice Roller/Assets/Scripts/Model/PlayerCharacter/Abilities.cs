using System.Collections.Generic;
using CaptainCoder.Dice;

namespace AdventureQuest.Character
{
    public class Abilities
    {
        private readonly Dictionary<Ability, AbilityScore> _abilities = new ();
        private Abilities(Dictionary<Ability, int> scores)
        {
            Total = 0;
            TotalModifiers = 0;
            foreach (Ability ability in scores.Keys)
            {
                AbilityScore score = new AbilityScore(ability, scores[ability]);
                _abilities[ability] = score;
                Total += score.Score;
                TotalModifiers += score.Modifier;
            }
        }

        public int Total { get; }
        public int TotalModifiers { get; }

        public AbilityScore Score(Ability ability) => _abilities[ability];
        

        public static Ability[] Types => (Ability[])System.Enum.GetValues(typeof(Ability));

        public static Abilities Roll()
        {
            Builder builder = new Builder();
            DicePool pool = DicePool.Parse("3d6");
            foreach (Ability ability in Types)
            {
                builder.SetScore(ability, pool.Roll());
            }
            return builder.Build();
        }

        public class Builder
        {
            private readonly Dictionary<Ability, int> _scores = new ();

            public Builder()
            {
                foreach (Ability a in Types)
                {
                    _scores[a] = 10;
                }
            }

            public Builder SetScore(Ability toSet, int value)
            {
                if (value < AbilityScore.MIN || value > AbilityScore.MAX)
                {
                    throw new System.ArgumentException($"Ability Score must be in range [{AbilityScore.MIN}, {AbilityScore.MAX}] but was {value}");
                }
                if (!_scores.ContainsKey(toSet))
                {
                    throw new System.ArgumentException($"Could not set ability of type {toSet}.");
                }
                _scores[toSet] = value;
                return this;
            }

            public Abilities Build()
            {
                Abilities abilities = new (_scores);
                return abilities;
            }
        }
    }
}