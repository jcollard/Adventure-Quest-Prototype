
using System.Collections.Generic;
using System.Diagnostics;
using AdventureQuest.Entity;
using AdventureQuest.Utils;

namespace AdventureQuest.Combat
{
    public class EncounterBuilder
    {
        private List<Enemy.Builder> _possibleEnemies = new();

        public EncounterBuilder AddEnemy(Enemy.Builder enemy, int count)
        {
            for (int i = 0; i < count; i++) { AddEnemy(enemy); }
            return this;
        }
        public EncounterBuilder AddEnemy(Enemy.Builder enemy)
        {
            _possibleEnemies.Add(enemy);
            return this;
        }

        public ICombatant Build()
        {
            Debug.Assert(_possibleEnemies.Count > 0);
            return _possibleEnemies.Random().Build();
        }
    }
}