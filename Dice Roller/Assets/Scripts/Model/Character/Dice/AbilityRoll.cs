using AdventureQuest.Dice;

namespace AdventureQuest.Character.Dice
{
    public class AbilityRoll
    {
        public AbilityRoll(IRollable baseRoll, RollModifier modifier)
        {
            BaseRoll = baseRoll;
            Modifier = modifier;
        }

        public IRollable BaseRoll { get; }
        public RollModifier Modifier { get; }

        public int Roll(Abilities abilities) => BaseRoll.Roll() + Modifier.ModifyWith(abilities);
    }
}