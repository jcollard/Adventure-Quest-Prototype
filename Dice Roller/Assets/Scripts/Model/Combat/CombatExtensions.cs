using AdventureQuest.Character;
using AdventureQuest.Entity;
using System;
using System.Linq;

namespace AdventureQuest.Combat
{
    public static class CombatExtensions
    {
        private static readonly Random _rng = new();
        /// <summary>
        /// Given a set of <paramref name="combatants"/> returns an array
        /// ordered with the "fastest" <see cref="ICombatant"/>'s first.
        /// "Fastest" is determined by the highest Agility score. If there is a
        /// tie, one is selected uniformly at random.
        /// </summary>
        public static ICombatant[] FindFastest(params ICombatant[] combatants)
        {
            return combatants
                    .OrderBy(_ => _rng.NextDouble())
                    .OrderByDescending(c => c.Abilities.Score(Ability.Agility).Score)
                    .ToArray();
        }
    }
}