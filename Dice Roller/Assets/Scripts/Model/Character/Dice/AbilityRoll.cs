using System.Collections.Generic;
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

        public static AbilityRoll Parse(string diceNotation)
        {
            string[] tokens = diceNotation.Trim().Split("+");
            List<DiceGroup> diceGroup = new ();
            List<string> rollModiferTokens = new ();
            foreach (string token in tokens)
            {
                if (DiceGroup.IsParseable(token))
                {
                    diceGroup.Add(DiceGroup.Parse(token));
                }
                else
                {
                    rollModiferTokens.Add(token);
                }
            }
            string rollModiferNotation = string.Join("+", rollModiferTokens);
            if (!RollModifier.IsParseable(rollModiferNotation)) { throw new System.FormatException($"Could not parse AbilityRoll from \"{diceNotation}\"."); }
            DicePool dicePool = new (diceGroup);
            RollModifier rollModifier = RollModifier.Parse(rollModiferNotation);
            return new AbilityRoll(dicePool, rollModifier);
        }
    }
}