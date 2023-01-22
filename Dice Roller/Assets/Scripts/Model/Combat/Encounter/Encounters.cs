
using System.Collections.Generic;
using System.Diagnostics;
using AdventureQuest.Entity;
using AdventureQuest.Utils;

namespace AdventureQuest.Combat
{
    public static class Encounters
    {
        public static EncounterBuilder CurrentEncounterBuilder { get; set; } = Forest;
        public static readonly EncounterBuilder Forest = new EncounterBuilder("forest")
            .AddEnemy(Enemies.Slime, 4)
            .AddEnemy(Enemies.DarkKnight)
            .AddEnemy(Enemies.DragonHawk)
            .AddEnemy(Enemies.Mimic)
            .AddEnemy(Enemies.FlamingSnowman);

        public static readonly EncounterBuilder Cemetery = new EncounterBuilder("cemetery")
            .AddEnemy(Enemies.DarkKnight)
            .AddEnemy(Enemies.StrawManOfDoom)
            .AddEnemy(Enemies.EarthKing)
            .AddEnemy(Enemies.Behemoth);

    }
}