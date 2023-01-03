using System.Collections.Generic;
using CaptainCoder.Dice;
using UnityEngine;

namespace AdventureQuest.Character
{
    [System.Serializable]
    public class Abilities : ISerializationCallbackReceiver
    {
        private Dictionary<Ability, AbilityScore> _abilities = new();
        [SerializeField]
        private List<AbilityScore> _abilityScores;
        private Abilities(List<AbilityScore> scores)
        {
            // In initial version, there will be no init / _abilityScores
            Init(scores);
        }

        public int Total { get; private set; }
        public int TotalModifiers { get; private set; }
        public AbilityScore Score(Ability ability) => _abilities[ability];
        public static Ability[] Types => (Ability[])System.Enum.GetValues(typeof(Ability));

        public static Abilities Roll()
        {
            Builder builder = new ();
            DicePool pool = DicePool.Parse("3d6");
            foreach (Ability ability in Types)
            {
                builder.SetScore(ability, pool.Roll());
            }
            return builder.Build();
        }

        public void OnBeforeSerialize(){}

        public void OnAfterDeserialize()
        {
            if (_abilityScores == null) return;
            Init(_abilityScores);
        }

        private void Init(List<AbilityScore> scores)
        {
            if (scores == null) { throw new System.ArgumentNullException("Cannot to set Scores to null list."); }
            Total = 0;
            TotalModifiers = 0;
            _abilities = new ();
            _abilityScores = scores;
            foreach (AbilityScore score in scores)
            {
                _abilities[score.Ability] = score;
                Total += score.Score;
                TotalModifiers += score.Modifier;
            }
        }

        public class Builder
        {
            private readonly Dictionary<Ability, int> _scores = new();

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
                List<AbilityScore> scores = new();
                foreach (KeyValuePair<Ability, int> entry in _scores)
                {
                    scores.Add(new AbilityScore(entry.Key, entry.Value));
                }
                Abilities abilities = new(scores);
                return abilities;
            }
        }
    }
}