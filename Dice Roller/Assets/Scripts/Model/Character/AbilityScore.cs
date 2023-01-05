using System.Collections.Generic;
using UnityEngine;
namespace AdventureQuest.Character
{
    [System.Serializable]
    public class AbilityScore
    {
        // Fields
        public AbilityScore(Ability ability, int score)
        {
            if (score  < 1 || score > 30) throw new System.ArgumentException($"Ability Score must be within range [1, 30] but was {score}.");
            Ability = ability;
            Score = score;
        }

        public string Name => Ability.ToString();
        [field: SerializeField]
        public Ability Ability { get; private set; }
        [field: SerializeField]
        public int Score { get; private set; }

        // 1     = -5
        // 2 - 3 = -4
        // 4 - 5 = -3
        // 6 - 7 = -2
        // 8 - 9 = -1
        // 10-11 = 0
        // 12-13 = 1
        // 14-15 = 2
        // 16-17 = 3
        // 18-19 = 4
        public int Modifier => (Score/2) - 5;

        public const int MIN = 1;
        public const int MAX = 30;

    }

}