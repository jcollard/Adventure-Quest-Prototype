
using System.Collections.Generic;
using System.Diagnostics;
using AdventureQuest.Entity;
using AdventureQuest.Utils;

namespace AdventureQuest.Combat
{
    public static class Encounters
    {
        public static readonly EncounterBuilder Forest = new EncounterBuilder()
            .AddEnemy(Enemies.Slime, 3)
            .AddEnemy(Enemies.DarkKnight);

        public static readonly EncounterBuilder Cemetary = new EncounterBuilder()
            .AddEnemy(Enemies.DarkKnight)
            .AddEnemy(Enemies.StrawManOfDoom);
    }
}